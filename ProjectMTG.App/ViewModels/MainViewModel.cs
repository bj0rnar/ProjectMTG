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
        private User _user = ShellViewModel.LoggedInUser;

        //Collections with getters
        private ObservableCollection<Card> ObservableCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableCards => ObservableCards;
        private ObservableCollection<Card> ObservableDeck = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableDeck => this.ObservableDeck;

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
                        if (param.types.Contains("Land"))
                        {
                            Land++;
                        }
                        else if (param.types.Contains("Instant") || param.types.Contains("Sorcery"))
                        {
                            InstantSorcery++;
                        }
                        else if (param.types.Contains("PlanesWalker"))
                        {
                            Planeswalker++;
                        }
                        else if (param.types.Contains("Creature"))
                        {
                            Creatures++;
                        }
                        else
                        {
                            Artifact++;
                        }

                        TotalCardCount++;
                        GetObservableDeck.Add(param);
                    }
                    else
                    {
                        //Legg te feilhåndtering?
                    }
                }
            }, card => card != null );

            RemoveCardFromDeck = new RelayCommand<Card>(param =>
            {
                if (param != null)
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

                    TotalCardCount--;
                    GetObservableDeck.Remove(param);
                }
            }, card => card != null );

            SaveDeckList = new RelayCommand<string>(async param =>
            {
                //Create new deck

                //Deck deck = Converter.ConvertToDatabaseDeck(GetObservableDeck);
               // Deck rere = new Deck() {DeckName = param, UserId = user.UserId};

               Deck deck = new Deck() {UserId = _user.UserId, DeckName = param};

               foreach (var card in GetObservableDeck)
               {
                   deck.Cards.Add(JsonConvert.DeserializeObject<DeckCard>(JsonConvert.SerializeObject(card)));
               }



                //Set deck to user
                //deck.UserId = _user.UserId;
                //Set deckname to parameter
                //deck.DeckName = param;

                /*
                Converter.ConvertToDatabaseDeck(GetObservableDeck);
                /*
                foreach (Card card in GetObservableDeck)
                {
                    //Add cards in acceptable database format
                    deck.Cards.Add(new DeckCards()
                    {
                        DeckId = deck.DeckId,
                        name = card.name,
                        artist = card.artist,
                        colors = card.colors,
                        convertedManaCost = card.convertedManaCost,
                        manaCost = card.manaCost,
                        multiverseId = card.multiverseId,
                        loyalty = card.loyalty,
                        number = card.number,
                        rarity = card.rarity,
                        scryfallId = card.scryfallId,
                        scryfallIllustrationId = card.scryfallIllustrationId,
                        scryfallOracleId = card.scryfallOracleId,
                        subtype = card.subtype,
                        supertype = card.supertype,
                        text = card.text,
                        type = card.type,
                        types = card.types,
                        uuid = card.uuid,
                        uuidV421 = card.uuidV421,
                        power = card.power,
                        toughness = card.toughness
                    });
                }
                */
                
                if (await _decksDataAccess.AddDeckAsync(deck))
                {
                    Debug.WriteLine("Success");
                    _user.Decks.Add(deck);
                }
                
                GetObservableDeck.Clear();
                

            }, s => !string.IsNullOrEmpty(s));

            SaveChanges = new RelayCommand<string>(async param =>
            {
                //var deckWithEditedCards = Converter.ConvertToEditableDeck(GetObservableDeck, EditDeck.DeckId);

                //deckWithEditedCards.DeckName = param;

                Deck newDeck = new Deck() {DeckName = param, DeckId = EditDeck.DeckId};

                foreach (var card in GetObservableDeck)
                {
                    var s = JsonConvert.DeserializeObject<DeckCard>(JsonConvert.SerializeObject(card));
                    s.DeckId = EditDeck.DeckId;
                    newDeck.Cards.Add(s);
                    Debug.WriteLine("DEckID: " + EditDeck.DeckId);
                    Debug.WriteLine("Kort sin DeckID: " + s.DeckId);
                }




                /*
               
                foreach (var card in EditDeck.Cards)
                {

                    foreach (var editCard in deckWithEditedCards.Cards)
                    {
                        if(card.DeckCardId != editCard.DeckCardId)
                    }


                    if (!deckWithEditedCards.Cards.Contains(card))
                    {
                        Debug.WriteLine("New card!: " + card.name + " <-- should probably add this to DB");
                    }
                }



                /* Shits not working
                foreach (var card in deckWithEditedCards.Cards)
                {
                    if (!EditDeck.Cards.Contains(card))
                    {
                        Debug.WriteLine("Missing card!: " + card.name + " <-- should remove this from DB");
                    }
                }


                /*
                if (databaseDeck != null)
                {
                    var userDeck = databaseDeck.FirstOrDefault(x => x.DeckId == EditDeck.DeckId);

                    if (userDeck != null)
                    {

                    }
                    else
                    {
                        Debug.WriteLine("Deck does not match UserID");
                    }


                }
                else
                {
                    Debug.WriteLine("Couldn't find deck");
                }


                /*
                var deckWithEditedCards = Converter.ConvertToEditableDeck(GetObservableDeck, EditDeck);

                var databaseDeck = await _decksDataAccess.GetUserDecksAsync(_user.UserId);

                var userDeck = databaseDeck.FirstOrDefault(x => x.DeckId == EditDeck.DeckId);

                if (userDeck != null)
                {
                    foreach (var card in deckWithEditedCards.Cards)
                    {
                        //If the card is a new card
                        if (!userDeck.Cards.Contains(card))
                        {
                            if (await _deckCardsDataAccess.AddDeckCardAsync(card))
                            {
                                Debug.WriteLine("Added new card successfully");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    foreach (var card in userDeck.Cards)
                    {
                        //If card is missing from deck
                        if (!deckWithEditedCards.Cards.Contains(card))
                        {
                            if (await _deckCardsDataAccess.DeleteDeckCardAsync(card))
                            {
                                Debug.WriteLine("Deleted card from deck");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }

                /*
                deckWithEditedCards.DeckName = param;
               
                if (await _decksDataAccess.EditDeckAsync(deckWithEditedCards))
                {
                    Debug.WriteLine("Edit cards success!");
                }
                */


                GetObservableDeck.Clear();

            }, s => !string.IsNullOrEmpty(s));

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
            foreach (var card in deck.Cards)
            {
                ObservableDeck.Add(JsonConvert.DeserializeObject<Card>(JsonConvert.SerializeObject(card)));
            }
            /*
            var cardList = Converter.ConvertToLocalCards(deck);
            foreach (var card in cardList)
            {
                ObservableDeck.Add(card);
            }
            */
        }
    }
}
