using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.LoadCardsAsync();
        }

        private void CardListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIndex = (Card) e.ClickedItem;
            ImageBox.Source = getBitmapImage(selectedIndex);
        }

        private void DeckListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIndex = (Card)e.ClickedItem;
            ImageBox.Source = getBitmapImage(selectedIndex);
        }

        private BitmapImage getBitmapImage(Card selectedIndex)
        {
            Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
            Uri indexUri = new Uri(baseUri, selectedIndex.scryfallId);
            Uri scryUri = new Uri(indexUri, "?format=image");
            var bitmapImage = new BitmapImage { UriSource = scryUri };
            return bitmapImage;
        }


        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {

            //var blue = ViewModel.GetObservableCards.Where(x => x.colors.Contains("U")).ToList();
            /*
            if (blue != null)
            {
                ViewModel.GetObservableCards.Clear();

                foreach (var card in blue)
                {
                    ViewModel.GetObservableCards.Add(card);
                }
            }

            /*var justblue = from i in ViewModel.GetObservableCards
                where i.colors.Contains("U")
                select i;
                */

            /*
            ViewModel.GetObservableCards.Clear();

            foreach (var card in blue)
            {
                ViewModel.GetObservableCards.Add(card);
            }
            
            foreach (var card in justblue)
            {
                ViewModel.GetObservableCards.Add(card);
            }
            */
        }


        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
