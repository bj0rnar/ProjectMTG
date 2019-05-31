using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;
using Remotion.Linq.Clauses;

namespace ProjectMTG.App.ViewModels
{
    public class DeckViewerViewModel : Observable
    {
        //Static user from MainViewModel, remove later
        private User _user = ShellViewModel.LoggedInUser;
        private Decks _decksDataAccess = new Decks();

        //Decklist
        private ObservableCollection<Deck> _observableDeckList = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetObservableDeckList => this._observableDeckList;

        //Imagelist
        private ObservableCollection<BitmapImage> _observableImage = new ObservableCollection<BitmapImage>();
        public ObservableCollection<BitmapImage> GetObservableImage => this._observableImage;

        public ICommand DeleteDeckCommand { get; }
        public ICommand EditDeckNameCommand { get; }

        private string _deckName;
        public string DeckName{ get => _deckName; set => Set(ref _deckName, value); }

        public DeckViewerViewModel()
        {
            DeleteDeckCommand = new RelayCommand<Deck>(DeleteDeck);
            EditDeckNameCommand = new RelayCommand<Deck>(EditDeckName);
        }


        /// <summary>Gets the user decks from database and sets them in ObservableCollection</summary>
        /// <returns></returns>
        internal async Task GetUserDecks()
        {
            Deck[] decks = null;
           
            decks = await _decksDataAccess.GetUserDecksAsync(_user.UserId).ConfigureAwait(true);
           

            if (decks != null)
            {
                foreach (Deck deck in decks)
                {
                    _observableDeckList.Add(deck);
                }
            }
            else
            {
                ToastCreator.ShowUserToast("Database connection lost: Cannot load user decks");
            }
        }


        /// <summary>Deletes user selected deck.</summary>
        /// <param name="deck">The deck.</param>
        private async void DeleteDeck(Deck deck)
        {
            if (deck != null)
            {
                if (!await _decksDataAccess.DeleteDeckAsync(deck).ConfigureAwait(true)) return;
                _observableDeckList.Remove(deck);
                _observableImage.Clear();

            }
            else
            {
                ToastCreator.ShowUserToast("Input error: Select a deck before pressing delete");
            }
        }


        /// <summary>Edits the name of the deck and saves to database</summary>
        /// <param name="deck">The deck.</param>
        private async void EditDeckName(Deck deck)
        {
            if (deck != null)
            {
                
                deck.DeckName = DeckName;

                if (!string.IsNullOrEmpty(deck.DeckName))
                {
                    if (await _decksDataAccess.EditDeckAsync(deck).ConfigureAwait(true))
                    {
                        _observableDeckList.Remove(deck);
                        _observableDeckList.Add(deck);
                    }
                    else
                    {
                        ToastCreator.ShowUserToast("Database connection lost: Cannot save edited deck name");
                    }
                }
                else
                {
                    ToastCreator.ShowUserToast("Input error: Missing name!");
                }
            }
            else
            {
                ToastCreator.ShowUserToast("Input error: Select a deck before editing name");
            }

        }



        /// <summary>Loads images from each card in deck and puts them in ObservableCollection</summary>
        /// <param name="selectedDeck">The selected deck.</param>
        /// <returns></returns>
        public async Task LoadImages(Deck selectedDeck)
        {
            _observableImage.Clear();

            foreach (var card in selectedDeck.Cards)
            {
                await Task.Delay(150).ConfigureAwait(true);
                Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
                Uri indexUri = new Uri(baseUri, card.scryfallId);
                Uri scryUri = new Uri(indexUri, "?format=image");
                var bitmapImage = new BitmapImage { UriSource = scryUri };
                GetObservableImage.Add(bitmapImage);

            }
            
        }
        
    }
}
