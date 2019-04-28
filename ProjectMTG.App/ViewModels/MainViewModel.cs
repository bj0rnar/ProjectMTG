using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class MainViewModel : Observable
    {
        //Static demo user
        public static User DemoUser = new User() {UserName = "DemoUser"};
        


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
        public ICommand ShowPicture { get; set; }

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
