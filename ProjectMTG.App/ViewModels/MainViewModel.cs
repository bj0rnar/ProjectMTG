using System;
using System.Collections;
using System.Collections.Generic;
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
        public ObservableCollection<Card> GetObservableCards => ObservableCards;
        private ObservableCollection<Card> ObservableDeck = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableDeck => this.ObservableDeck;


        //Filtered data
        public ObservableCollection<Card> DisplayCards { get; set; }  = new ObservableCollection<Card>();

        //Filtered out database.
        private Cards cardsDataAccess = new Cards();
        private Decks decksDataAccess = new Decks();
        private Users usersDataAccess = new Users();

        //Command
        public ICommand AddCardToDeck { get; set; }
        public ICommand RemoveCardFromDeck { get; set; }
        public ICommand SaveDeckList { get; set; }
        private ICommand searchText;

        //DataStream (needed for filtering)
        public Card[] CompleteList;

        public MainViewModel()
        {

            AddCardToDeck = new RelayCommand<Card>( param =>
            {
                if (param != null)
                {
                    //Check for equal cards
                    var checkForEqualCards = GetObservableDeck.Where(u => u.Equals(param));
                    var equalCardCounter = checkForEqualCards.Count();

                    //If duplicate cards are more than 4 or card is a Land type.
                    if (equalCardCounter < 4 || param.types.Contains("Land"))
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
           
                Deck deck = new Deck() {DeckName = param};

                //Add duplicates to dictionary
               /* var duplicateCheck = GetObservableDeck.GroupBy(x => x)
                    .Where(z => z.Count() > 1)
                    .ToDictionary(x => x.Key, y => y.Count());
                
                */
               
                foreach (Card card in GetObservableDeck)
                {
                    //Only add unique cards.
                    //if(GetObservableDeck.Any(p => p.CardId == card.CardId) == false) deck.Cards.Add(card);
                    deck.Cards.Add(card);
                }

                
                //Doesn't save to database.
                user.Decks.Add(deck);
                /*
                if (await decksDataAccess.AddDeckAsync(deck))
                {
                    Debug.WriteLine("Success");
                    user.Decks.Add(deck);
                }
                */
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


            /*
            FilteredBlueCommand = new RelayCommand<bool>(param =>
            {
                if (param)
                {
                    var query = ObservableCards.Where(u => u.name == "Mountain").ToList();
                    DisplayCards = new ObservableCollection<Card>(query);
                }
                else
                {
                    DisplayCards = ObservableCards;
                }

            });
            */
        }

        //AutoSuggestBox dynamic search
        public ICommand SearchText
        {
            get
            {
                if (searchText == null)
                {

                    searchText = new RelayCommand<string>(param =>
                    {
                        if (!string.IsNullOrEmpty(param))
                        {
                            var temp = new ObservableCollection<Card>(GetObservableCards.Where(x => x.name.ToLower().StartsWith(param.ToLower())));
                            DisplayCards.Clear();
                            foreach (var card in temp)
                            {
                                DisplayCards.Add(card);
                            }
                        }
                        else
                        {
                            DisplayCards.Clear();
                            foreach (var card in GetObservableCards)
                            {
                                DisplayCards.Add(card);
                            }
                            Debug.WriteLine("Its empty!");
                        }
                    });
                }
               return searchText;
            }
        }


        internal async Task LoadCardsAsync()
        {
            CompleteList = await cardsDataAccess.GetCardsAsync();
            foreach (Card card in CompleteList)
            {
                ObservableCards.Add(card);
                DisplayCards.Add(card);
            }
        }
    }
}
