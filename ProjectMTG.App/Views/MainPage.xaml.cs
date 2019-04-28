using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();

            //DeckListView.ItemsSource = 

            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.LoadCardsAsync();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            foreach (ListViewItem selectedCard in CardListView.SelectedItems)
            {
                DeckListView.Items.Add((ListViewItem)selectedCard);
            }
            */
        }

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
