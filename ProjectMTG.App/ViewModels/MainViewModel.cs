using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class MainViewModel : Observable
    {
        private ObservableCollection<Card> ObservableCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableCards => this.ObservableCards;

        private ObservableCollection<Card> ObservableDeck = new ObservableCollection<Card>();
        public ObservableCollection<Card> GetObservableDeck => this.ObservableDeck;
        private Cards cardsDataAccess = new Cards();

        public MainViewModel()
        {
            this.ObservableCards.Add(new Card() { name = "CardTest"});
        }




        //Denna metoda funke ikkje, spør um hjelp.
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
