﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
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

        //Load decks from user
        internal async Task GetUserDecks()
        {
            var decks = await _decksDataAccess.GetUserDecksAsync(_user.UserId);
            foreach (Deck deck in decks)
            {
                _observableDeckList.Add(deck);
            }
        }

        //Delete deck
        private async void DeleteDeck(Deck deck)
        {
            if (await _decksDataAccess.DeleteDeckAsync(deck))
            {
                _observableDeckList.Remove(deck);
                _observableImage.Clear();
            }
        }

        //Edit deckname
        private async void EditDeckName(Deck deck)
        {
            deck.DeckName = DeckName;

            if (!string.IsNullOrEmpty(deck.DeckName))
            {
                if (await _decksDataAccess.EditDeckAsync(deck))
                {
                    _observableDeckList.Remove(deck);
                    _observableDeckList.Add(deck);
                }
            }
            
        }


        //Load images from decks. Internal?
        public async Task LoadImages(Deck selectedDeck)
        {
            _observableImage.Clear();

            foreach (var card in selectedDeck.Cards)
            {
                await Task.Delay(150);
                Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
                Uri indexUri = new Uri(baseUri, card.scryfallId);
                Uri scryUri = new Uri(indexUri, "?format=image");
                var bitmapImage = new BitmapImage { UriSource = scryUri };
                GetObservableImage.Add(bitmapImage);
            }
            
        }

        
    }
}
