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
            Loaded += LoadUserDecks;
            Loaded += MainPage_Loaded;
            ShowSelectDialog(ViewModel.ContentDialogDecks);
        }

        private async void LoadUserDecks(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetUserDecks();
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.LoadCardsAsync();
        }

        private async void ShowSelectDialog(ObservableCollection<Deck> userDeckList)
        {
            ContentDialog1 startUpDialog = new ContentDialog1(userDeckList);
            await startUpDialog.ShowAsync();

            //User selected edit in popup window, load cards in deck and set in editormode
            if (startUpDialog.choice == UserChoice.Edit)
            {
                Debug.WriteLine("Edit clicked");

                if (startUpDialog.Content != null)
                {
                    Deck deck = (Deck) startUpDialog.Content;
                    ViewModel.LoadDeckCards(deck);
                    ViewModel.EditorMode = true;
                    SaveDecklistButton.Visibility = Visibility.Collapsed;
                    DeckListName.Visibility = Visibility.Collapsed;
                    SaveChangesButton.Visibility = Visibility.Visible;
                    ViewModel.EditDeck = deck;
                }
                else
                {
                    startUpDialog.choice = UserChoice.Create;
                }
            }

            //User selected create in popup window, show default window settings.
            if (startUpDialog.choice == UserChoice.Create)
            {
                Debug.WriteLine("Create clicked");
                ViewModel.EditorMode = false;
                SaveChangesButton.Visibility = Visibility.Collapsed;
                SaveDecklistButton.Visibility = Visibility.Visible;
                DeckListName.Visibility = Visibility.Visible;
            }

        }

        //Load image for clicked card
        private void CardListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIndex = (Card) e.ClickedItem;
            ImageBox.Source = getCardImage(selectedIndex);
        }

        //Load image for clicked card
        private void DeckListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIndex = (DeckCard)e.ClickedItem;
            ImageBox.Source = getDeckCardImage(selectedIndex);
        }

        private BitmapImage getDeckCardImage(DeckCard selectedIndex)
        {
            Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
            Uri indexUri = new Uri(baseUri, selectedIndex.scryfallId);
            Uri scryUri = new Uri(indexUri, "?format=image");
            var bitmapImage = new BitmapImage { UriSource = scryUri };
            return bitmapImage;
        }

        //Get image from Scryfall
        private BitmapImage getCardImage(Card selectedIndex)
        {
            Uri baseUri = new Uri("https://api.scryfall.com/cards/)");
            Uri indexUri = new Uri(baseUri, selectedIndex.scryfallId);
            Uri scryUri = new Uri(indexUri, "?format=image");
            var bitmapImage = new BitmapImage { UriSource = scryUri };
            return bitmapImage;
        }

        //Filter based on checkbox isChecked name
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
