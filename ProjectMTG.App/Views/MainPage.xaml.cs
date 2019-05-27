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

        /* Manuell måte å gjerra dæ på.
        private void BlueCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            var blue = ViewModel.GetObservableCards.Where(x => x.colors.Contains("U"));

            ViewModel.DisplayCards.Clear();

            foreach (var card in blue)
            {
                ViewModel.DisplayCards.Add(card);
            }
        }

        private void BlueCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ViewModel.DisplayCards.Clear();

            foreach (var card in ViewModel.GetObservableCards)
            {
                ViewModel.DisplayCards.Add(card);
            }

        }
        */

        private void CheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            CheckBox[] checkboxes = new CheckBox[] {BlueCheckbox, BlackCheckBox, GreenCheckBox, ColorlessCheckBox, RedCheckBox, WhiteCheckBox, ColorlessCheckBox};
            int falseCount = 0;

            ViewModel.DisplayCards.Clear();

            foreach (CheckBox checkbox in checkboxes)
            {
                if (checkbox.IsChecked == true)
                {
                    falseCount++;
                    switch (checkbox.Name)
                    {
                        case "BlueCheckBox":
                            var blue = ViewModel.GetObservableCards.Where(x => x.colors.Contains("U"));
                            foreach (var card in blue){ ViewModel.DisplayCards.Add(card); }
                            break;
                        case "RedCheckBox":
                            var red = ViewModel.GetObservableCards.Where(x => x.colors.Contains("R"));
                            foreach (var card in red) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "BlackCheckBox":
                            var black = ViewModel.GetObservableCards.Where(x => x.colors.Contains("B"));
                            foreach (var card in black) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "WhiteCheckBox":
                            var white = ViewModel.GetObservableCards.Where(x => x.colors.Contains("W"));
                            foreach (var card in white) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "GreenCheckBox":
                            var green = ViewModel.GetObservableCards.Where(x => x.colors.Contains("G"));
                            foreach (var card in green) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "ColorlessCheckBox":
                            var colorless = ViewModel.GetObservableCards.Where(x => x.colors.Length == 0);
                            foreach (var card in colorless) { ViewModel.DisplayCards.Add(card); }
                            break;
                    }
                }
            }

            if (falseCount == 0)
            {
                foreach (var card in ViewModel.GetObservableCards)
                {
                    ViewModel.DisplayCards.Add(card);
                }
            }
        }
    }
}
