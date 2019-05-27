using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class SimulationViewModel : Observable
    {

        private User User = ShellViewModel.LoggedInUser;

        private static Random randomGenerator = new Random();

        private ObservableCollection<Deck> ComboBoxDecks = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetComboBoxDecks => this.ComboBoxDecks;

        private ObservableCollection<Card> DisplayCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetDisplayCards => this.DisplayCards;

        public SimulationViewModel()
        {
            foreach (var deck in User.Decks)
            {
                ComboBoxDecks.Add(deck);
            }
        }

        public void DrawNewHand(Deck selectedDeck)
        {
            
        }
    }
}
