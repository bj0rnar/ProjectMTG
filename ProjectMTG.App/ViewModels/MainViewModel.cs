﻿using System;
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
                        //Legg te feilhåndtering?
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
                //Create new deck
           
                Deck deck = new Deck() {DeckName = param, UserId = user.UserId};

               
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
                
                
                if (await decksDataAccess.AddDeckAsync(deck))
                {
                    Debug.WriteLine("Success");
                    user.Decks.Add(deck);
                }
                
                GetObservableDeck.Clear();
                
                

            }, s => !string.IsNullOrEmpty(s));

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
