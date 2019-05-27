using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class SimulationViewModel : Observable
    {

        private User user = ShellViewModel.LoggedInUser;

        private static Random randomGenerator = new Random();

        private Decks decksDataAccess = new Decks();

        private ObservableCollection<Deck> ComboBoxDecks = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetComboBoxDecks => this.ComboBoxDecks;

        private ObservableCollection<DeckCards> DisplayCards = new ObservableCollection<DeckCards>();
        public ObservableCollection<DeckCards> GetDisplayCards => this.DisplayCards;

        private ObservableCollection<BitmapImage> DisplayImages = new ObservableCollection<BitmapImage>();
        public ObservableCollection<BitmapImage> GetDisplayImages => this.DisplayImages;

        public SimulationViewModel()
        {
            
        }

        internal async Task LoadDecks()
        {
            var decks = await decksDataAccess.GetUserDecksAsync(user.UserId);

            foreach (var deck in decks)
            {
                ComboBoxDecks.Add(deck);
            }
        }

        
        public async void DrawNewHand(Deck selectedDeck)
        {
            GetDisplayCards.Clear();
            GetDisplayImages.Clear();

            var randomList = selectedDeck.Cards.TakeRandom(7);

            foreach (var card in randomList)
            {
                await Task.Delay(150);
                var baseUri = new Uri("https://api.scryfall.com/cards/)");
                var indexUri = new Uri(baseUri, card.scryfallId);
                var scryUri = new Uri(indexUri, "?format=image");
                var bitmapImage = new BitmapImage { UriSource = scryUri };
                GetDisplayImages.Add(bitmapImage);
                GetDisplayCards.Add(card);
            }
          
        }
        
    }
}
