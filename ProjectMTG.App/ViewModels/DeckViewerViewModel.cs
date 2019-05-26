﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private User User = ShellViewModel.LoggedInUser;
        private Decks decksDataAccess = new Decks();

        private ObservableCollection<Deck> ObservableDeckList = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetObservableDeckList => this.ObservableDeckList;

        private ObservableCollection<BitmapImage> ObservableImage = new ObservableCollection<BitmapImage>();
        public ObservableCollection<BitmapImage> GetObservableImage => this.ObservableImage;

        public DeckViewerViewModel()
        {
            /*
            foreach (Deck deck in User.Decks)
            {
                ObservableDeckList.Add(deck);
            }
            */
        }

        //Load decks from user
        internal async Task GetUserDecks()
        {

            /*
            var decks = await decksDataAccess.GetUserDecksAsync(User.UserId).ConfigureAwait(false);
            foreach (Deck deck in decks)
            {
                ObservableDeckList.Add(deck);
            }
            */
        }


        //Load images from decks.
        public async Task LoadImages(Deck selectedDeck)
        {
            
            GetObservableImage.Clear();

            var query = from card in selectedDeck.Cards
                        select card;
            /*
            foreach (var card in query)
            {
                await Task.Delay(150);
                Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
                Uri indexUri = new Uri(baseUri, card.scryfallId);
                Uri scryUri = new Uri(indexUri, "?format=image");
                var bitmapImage = new BitmapImage { UriSource = scryUri };
                GetObservableImage.Add(bitmapImage);
            }
            */
            
        }

        
    }
}
