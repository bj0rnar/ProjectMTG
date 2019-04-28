using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static Uri ScryfallUri = new Uri("https://api.scryfall.com/cards/84f2c8f5-8e11-4639-b7de-00e4a2cbabee?format=image");
        private readonly HttpClient HttpClient = new HttpClient();

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
            Debug.WriteLine(selectedIndex.name);
            Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
            Uri indexUri = new Uri(baseUri, selectedIndex.scryfallId);
            Uri scryUri = new Uri(indexUri, "?format=image");
            var bitmapImage = new BitmapImage {UriSource = scryUri};
            ImageBox.Source = bitmapImage;


        }

        private void DeckListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIndex = (Card)e.ClickedItem;
            Debug.WriteLine(selectedIndex.name);
            Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
            Uri indexUri = new Uri(baseUri, selectedIndex.scryfallId);
            Uri scryUri = new Uri(indexUri, "?format=image");
            var bitmapImage = new BitmapImage { UriSource = scryUri };
            ImageBox.Source = bitmapImage;
        }

        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            foreach (ListViewItem selectedCard in CardListView.SelectedItems)
            {
                DeckListView.Items.Add((ListViewItem)selectedCard);
            }
            */
        //}

        /*
        private static void AddCardsToDeck(ListView cardView, ListView deckView)
        {
            foreach (Card selectedItem in cardView.SelectedItems)
            {
                deckView.Items.Add((Card)selectedItem);
            }
        }
        */

      
    }
}
