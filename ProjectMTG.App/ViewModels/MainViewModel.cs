using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.UI.Xaml.Data;
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
        public User user = ShellViewModel.LoggedInUser;

        //Collections with getters
        private ObservableCollection<Card> ObservableCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableCards => this.ObservableCards;
        private ObservableCollection<Card> ObservableDeck = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableDeck => this.ObservableDeck;

        //Filtered out database.
        private Cards cardsDataAccess = new Cards();
        private Decks decksDataAccess = new Decks();
        private Users usersDataAccess = new Users();

        //Command
        public ICommand AddCardToDeck { get; set; }
        public ICommand RemoveCardFromDeck { get; set; }
        public ICommand SaveDeckList { get; set; }

        
        public int CardCounter => GetObservableDeck.Count;

        public MainViewModel()
        {

            Debug.WriteLine(user.UserName);

            AddCardToDeck = new RelayCommand<Card>( param =>
            {
                if (param != null)
                {
                    //Check for equal cards
                    var checkForEqualCards = GetObservableDeck.Where(u => u.Equals(param));
                    var equalCardCounter = checkForEqualCards.Count();

                    if (equalCardCounter < 4)
                    {
                        GetObservableDeck.Add(param);
                    }
                    else
                    {
                        Debug.WriteLine("Faggot");
                    }
                }
            }, card => card != null );

            RemoveCardFromDeck = new RelayCommand<Card>(param =>
            {
                if (param != null)
                {
                    GetObservableDeck.Remove(param);
                }
            }, card => card != null );

            SaveDeckList = new RelayCommand<string>(async param =>
            {
                //Not saving directly to DB yet, this is just proof of concept for beta. Wanna fix user login before starting with this.
                //Rework this into method like GetCardsAsync, but with Serialize(deck) to json and upload.
                //Verify input.
           
                Deck deck = new Deck() {DeckName = param, User = user};

                foreach (Card card in GetObservableDeck)
                {
                    deck.Cards.Add(card);
                    Debug.WriteLine(card.name);
                }
                //Cheap method
                user.Decks.Add(deck);

                GetObservableDeck.Clear();

                /*
                if (await decksDataAccess.AddDeckAsync(deck))
                {
                    Debug.WriteLine("Success");
                }

                /*  FIX LATER
                if (await decksDataAccess.AddDeckAsync(deck))
                {
                    Debug.WriteLine("Success!");
                }
                */

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
