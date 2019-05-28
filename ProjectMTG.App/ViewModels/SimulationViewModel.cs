using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class SimulationViewModel : Observable, INotifyPropertyChanged
    {

        private User user = ShellViewModel.LoggedInUser;

        private Decks decksDataAccess = new Decks();

        private ObservableCollection<Deck> ComboBoxDecks = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetComboBoxDecks => this.ComboBoxDecks;

        private ObservableCollection<DeckCards> DisplayCards = new ObservableCollection<DeckCards>();
        public ObservableCollection<DeckCards> GetDisplayCards => this.DisplayCards;

        private ObservableCollection<BitmapImage> DisplayImages = new ObservableCollection<BitmapImage>();
        public ObservableCollection<BitmapImage> GetDisplayImages => this.DisplayImages;

        public double ZeroLand { get; set; }
        public double OneLand { get; set; }
        public double TwoLand { get; set; }
        public double ThreeLand { get; set; }
        public double FourLand { get; set; }
        public double FiveLand { get; set; }
        public double SixLand { get; set; }
        public double SevenLand { get; set; }


        public ICommand SimulateDrawCommand { get; }


        public SimulationViewModel()
        {
            SimulateDrawCommand = new RelayCommand<Deck>(SimulateDraw, param => param != null);
        }

        internal async Task LoadDecks()
        {
            var decks = await decksDataAccess.GetUserDecksAsync(user.UserId);

            foreach (var deck in decks)
            {
                ComboBoxDecks.Add(deck);
            }
        }

        private void SimulateDraw(Deck deck)
        {
            ZeroLand = 0;
            OneLand = 0;
            TwoLand = 0;
            ThreeLand = 0;
            FourLand = 0;
            FiveLand = 0;
            SixLand = 0;
            SevenLand = 0;

            int landPerDraw = 0;

            for (var i = 0; i < 100; i++)
            {
                var randomizedList = deck.Cards.TakeRandom(7);

                foreach (var card in randomizedList)
                {
                    if (card.types.Contains("Land"))
                    {
                        landPerDraw++;
                    }
                }

                switch (landPerDraw)
                {
                    case 0:
                        ZeroLand++;
                        break;
                    case 1:
                        OneLand++;
                        break;
                    case 2:
                        TwoLand++;
                        break;
                    case 3:
                        ThreeLand++;
                        break;
                    case 4:
                        FourLand++;
                        break;
                    case 5:
                        FiveLand++;
                        break;
                    case 6:
                        SixLand++;
                        break;
                    case 7:
                        SevenLand++;
                        break;
                    default: //Default means more than seven
                        SevenLand++;
                        break;
                }

                landPerDraw = 0;

            }

            Debug.WriteLine("Zeroland" + ZeroLand);
            Debug.WriteLine("Oneland % " + OneLand);
            Debug.WriteLine("Twoland % " + TwoLand);
            Debug.WriteLine("Threeland % " + ThreeLand);
            Debug.WriteLine("Fourland % " + FourLand);
            Debug.WriteLine("Fiveland % " + FiveLand);
            Debug.WriteLine("Sixland % " + SixLand);
            Debug.WriteLine("Sevenland % " + SevenLand);



        }

        public async void DrawNewHand(Deck selectedDeck, int draw)
        {
            GetDisplayCards.Clear();
            GetDisplayImages.Clear();

            var randomList = selectedDeck.Cards.TakeRandom(draw);

            foreach (var card in randomList)
            {
                await Task.Delay(150);
                var baseUri = new Uri("https://api.scryfall.com/cards/)");
                var indexUri = new Uri(baseUri, card.scryfallId);
                var scryUri = new Uri(indexUri, "?format=image");
                var bitmapImage = new BitmapImage { UriSource = scryUri };
                GetDisplayImages.Add(bitmapImage);
                GetDisplayCards.Add(card);
            }
          
        }
        
    }
}
