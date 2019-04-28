using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Newtonsoft.Json;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.DataAccess;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class MainViewModel : Observable
    {
        //Static demo user
        public static User DemoUser { get; set; } = new User() {UserName = "DemoUser"};
        


        //Collections with getters
        private ObservableCollection<Card> ObservableCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableCards => this.ObservableCards;
        private ObservableCollection<Card> ObservableDeck = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableDeck => this.ObservableDeck;

        //Filtered out database.
        private Cards cardsDataAccess = new Cards();

        //Command
        public ICommand AddCardToDeck { get; set; }
        public ICommand RemoveCardFromDeck { get; set; }
        public ICommand SaveDeckList { get; set; }

        public MainViewModel()
        {
            AddCardToDeck = new RelayCommand<Card>( param =>
            {
                if (param != null)
                {
                    GetObservableDeck.Add(param);
                }
            }, card => card != null );

            RemoveCardFromDeck = new RelayCommand<Card>(param =>
            {
                if (param != null)
                {
                    GetObservableDeck.Remove(param);
                }
            }, card => card != null );

            SaveDeckList = new RelayCommand<string>(param =>
            {
                //Not saving directly to DB yet, this is just proof of concept for beta. Wanna fix user login before starting with this.
                //Rework this into method like GetCardsAsync, but with Serialize(deck) to json and upload.

                Deck deck = new Deck() {DeckName = param, User = DemoUser};

                foreach (Card card in GetObservableDeck)
                {
                    deck.Cards.Add(card);
                    Debug.WriteLine(card.name);
                }

                DemoUser.Decks.Add(deck);

            }, s => !string.IsNullOrEmpty(s));
        }


        internal async Task LoadCardsAsync()
        {
            var cards = await cardsDataAccess.GetCardsAsync();
            foreach (Card card in cards)
            {
                ObservableCards.Add(card);
            }
        }
    }
}
