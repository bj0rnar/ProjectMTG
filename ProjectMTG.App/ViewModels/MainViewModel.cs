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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Views;
using ProjectMTG.DataAccess;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class MainViewModel : Observable
    {
        //Static demo user
        private User _user = ShellViewModel.LoggedInUser;

        //Collections with getters
        private ObservableCollection<Card> ObservableCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableCards => ObservableCards;
        private ObservableCollection<DeckCard> ObservableDeck = new ObservableCollection<DeckCard>();
        public ObservableCollection<DeckCard> GetObservableDeck => this.ObservableDeck;

        //See if user is edit mode
        public bool EditorMode { get; set; }
        public Deck EditDeck { get; set; }

        //Filtered data
        public ObservableCollection<Card> DisplayCards { get; set; }  = new ObservableCollection<Card>();

        //ContentDialog Decks
        public ObservableCollection<Deck> ContentDialogDecks { get; set; } = new ObservableCollection<Deck>();

        //Filtered out database.
        private Cards _cardsDataAccess = new Cards();
        private Decks _decksDataAccess = new Decks();
        private DeckCards _deckCardsDataAccess = new DeckCards();

        //Command
        public ICommand AddCardToDeck { get; set; }
        public ICommand RemoveCardFromDeck { get; set; }
        public ICommand SaveDeckList { get; set; }
        private ICommand _searchText;
        public ICommand SaveChanges { get; set; }

        //DataStream (needed for filtering)
        public Card[] CompleteList;

        //how 2 use?
        private ILogger _logger;


        private int _creatures;
        public int Creatures { get => _creatures; set => Set(ref _creatures, value); }
        private int _land;
        public int Land { get => _land; set => Set(ref _land, value); }
        private int _instantSorcery;
        public int InstantSorcery { get => _instantSorcery; set => Set(ref _instantSorcery, value); }
        private int _planeswalker;
        public int Planeswalker { get => _planeswalker; set => Set(ref _planeswalker, value); }
        private int _totalCardCount;
        public int TotalCardCount { get => _totalCardCount; set => Set(ref _totalCardCount, value); }
        private int _artifact;
        public int Artifact { get => _artifact; set => Set(ref _artifact, value); }




        public MainViewModel()
        {

            //Convert from baseCard to DeckCard
            AddCardToDeck = new RelayCommand<Card>( param =>
            {
                if (param != null)
                {
                    DeckCard converted = new DeckCard();
                    converted = JsonConvert.DeserializeObject<DeckCard>(JsonConvert.SerializeObject(param));
                    if (converted != null)
                    {
                        //Check for equal cards
                        var equalCardCounter = 0;

                        foreach (var card in GetObservableDeck)
                        {
                            if (card.name == converted.name)
                            {
                                equalCardCounter++;
                            }
                        }

                        //var checkForEqualCards = GetObservableDeck.Where(u => u.Equals(converted.name));
                        //var equalCardCounter = checkForEqualCards.Count();

                        //If duplicate cards are more than 4 or card is a Land type.
                        if (equalCardCounter < 4 || converted.types.Contains("Land"))
                        {
                            IncreaseCardCounter(converted);

                            TotalCardCount++;
                            GetObservableDeck.Add(converted);
                        }
                        else
                        {
                            ToastCreator.ShowUserToast("Only four equal cards allowed");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Could not convert");
                    }
                }
            }, card => card != null );

            //Remove card from observablelist
            RemoveCardFromDeck = new RelayCommand<DeckCard>(param =>
            {
                if (param != null)
                {
                    DecreaseCardCounter(param);

                    TotalCardCount--;
                    GetObservableDeck.Remove(param);
                }
            }, card => card != null );

            SaveDeckList = new RelayCommand<string>(async param =>
            {
               //Dummy deck
               Deck deck = new Deck() {UserId = _user.UserId, DeckName = param};

               //Get from newly created list
               foreach (var card in GetObservableDeck)
               {
                   deck.Cards.Add(card);
               }

                //Upload
                try
                {
                    if (await _decksDataAccess.AddDeckAsync(deck))
                    {
                        ToastCreator.ShowUserToast("Deck successfully saved");
                        _user.Decks.Add(deck);
                        GetObservableDeck.Clear();
                    }
                }
                catch (HttpRequestException ex)
                {
                    ToastCreator.ShowUserToast("No internet connection, was not able to save deck");
                }

                

            }, s => !string.IsNullOrEmpty(s));

            SaveChanges = new RelayCommand<string>(async param =>
            {
                //Has to be cards to save changes, otherwise start deletedialog
                if (GetObservableDeck.Count > 0)
                {

                    //Check if a new card is added, if new add to DB
                    foreach (var card in GetObservableDeck)
                    {
                        //Not assigned value means a new card
                        if (card.DeckCardId == 0)
                        {
                            //Edit deck is the original selected deck
                            card.DeckId = EditDeck.DeckId;

                            if (await _deckCardsDataAccess.AddDeckCardAsync(card))
                            {
                                Debug.WriteLine("Successfully added new card");
                                //TODO: Feilhåndtering
                            }

                        }

                    }

                    //Check if card is missing, if missing delete 
                    foreach (var card in EditDeck.Cards)
                    {
                        //Check if card does not exist in new list
                        if (!GetObservableDeck.Contains(card))
                        {
                            if (await _deckCardsDataAccess.DeleteDeckCardAsync(card))
                            {
                                Debug.WriteLine("Successfully deleted card");
                                //TODO: Feilhåndtering
                            }
                        }
                    }


                    GetObservableDeck.Clear();
                }
                else
                {
                    EmptyDeckWarning deckWarningDialog = new EmptyDeckWarning();
                    await deckWarningDialog.ShowAsync();

                    if (deckWarningDialog.DeleteChoice == DeletionChoices.Keep)
                    {
                        //Do nothing
                    }
                    else if (deckWarningDialog.DeleteChoice == DeletionChoices.Delete)
                    {
                        try
                        {
                            //Delete deck
                            if (await _decksDataAccess.DeleteDeckAsync(EditDeck))
                            {
                                EditDeck = null;
                                ToastCreator.ShowUserToast("Deck successfully deleted");
                            }
                        }
                        catch (HttpRequestException)
                        {
                            ToastCreator.ShowUserToast("No internet connection, can't delete deck");
                        }
                    }
                    else
                    {
                        ToastCreator.ShowUserToast("Unexpected error");
                    }

                }

            }, string.IsNullOrEmpty);

        }

        private void DecreaseCardCounter(DeckCard param)
        {
            if (param.types.Contains("Land"))
            {
                Land--;
            }
            else if (param.types.Contains("Instant") || param.types.Contains("Sorcery"))
            {
                InstantSorcery--;
            }
            else if (param.types.Contains("PlanesWalker"))
            {
                Planeswalker--;
            }
            else if (param.types.Contains("Creature"))
            {
                Creatures--;
            }
            else
            {
                Artifact--;
            }
        }

        private void IncreaseCardCounter(DeckCard converted)
        {
            if (converted.types.Contains("Land"))
            {
                Land++;
            }
            else if (converted.types.Contains("Instant") || converted.types.Contains("Sorcery"))
            {
                InstantSorcery++;
            }
            else if (converted.types.Contains("PlanesWalker"))
            {
                Planeswalker++;
            }
            else if (converted.types.Contains("Creature"))
            {
                Creatures++;
            }
            else
            {
                Artifact++;
            }
        }

        //AutoSuggestBox dynamic search
        public ICommand SearchText
        {
            get
            {
                if (_searchText == null)
                {

                    _searchText = new RelayCommand<string>(param =>
                    {
                        if (!string.IsNullOrEmpty(param))
                        {
                            var temp = new ObservableCollection<Card>(DisplayCards.Where(x => x.name.ToLower().StartsWith(param.ToLower())));
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
                                //TODO Detta skjit te filteren, finn ut no anna lurt
                                DisplayCards.Add(card);
                            }
                        }
                    });
                }
               return _searchText;
            }
        }


        internal async Task LoadCardsAsync()
        {
            CompleteList = await _cardsDataAccess.GetCardsAsync();
            foreach (Card card in CompleteList)
            {
                ObservableCards.Add(card);
                DisplayCards.Add(card);
            }
        }

        internal async Task GetUserDecks()
        {
            var decks = await _decksDataAccess.GetUserDecksAsync(_user.UserId);
            foreach (Deck deck in decks)
            {
                ContentDialogDecks.Add(deck);
            }
            
        }

        public void LoadDeckCards(Deck deck)
        {
            if (deck != null)
            {
                foreach (var card in deck.Cards)
                {
                    ObservableDeck.Add(card);
                }
                
            }
            else
            {
                throw new ArgumentException("No deck found");
            }

        }
    }
}
