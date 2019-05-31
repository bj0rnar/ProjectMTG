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
using Newtonsoft.Json;
using ProjectMTG.App.Helpers;
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
            try
            {
                await ViewModel.GetUserDecks();
            }
            catch (HttpRequestException ex)
            {
                ToastCreator.ShowUserToast("No database connection, can't display user decks");
            }
            catch (JsonReaderException ex)
            {
                ToastCreator.ShowUserToast("No database connection, can't display user decks");
            }
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                await ViewModel.LoadCardsAsync().ConfigureAwait(true);
            }
            catch (HttpRequestException ex)
            {
                ToastCreator.ShowUserToast("No database connection, can't load cards");
            }
            catch (NullReferenceException ex)
            {
                ToastCreator.ShowUserToast("No database connection, can't find cards");
            }
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


        /// <summary>Handles the OnClick event of the CheckBox control.
        /// Filters the ObservableCollection in viewmodel based on color</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            CheckBox[] checkboxes = new CheckBox[] {BlueCheckBox, BlackCheckBox, GreenCheckBox, ColorlessCheckBox, RedCheckBox, WhiteCheckBox, ColorlessCheckBox};
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


        /// <summary>Handles the Onclick event of the Typebox control.
        /// Filters the ObservableCollection in Viewmodel based on type</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Typebox_Onclick(object sender, RoutedEventArgs e)
        {
            CheckBox[] checkboxes = new CheckBox[] { LandCheckBox, CreatureCheckBox, PlaneswalkerCheckBox, ArtifactCheckBox, InstantCheckBox, SorceryCheckBox };
            ViewModel.DisplayCards.Clear();

            int falseCount = 0;

            foreach (CheckBox checkbox in checkboxes)
            {
                if (checkbox.IsChecked == true)
                {
                    falseCount++;
                    switch (checkbox.Name)
                    {
                        case "LandCheckBox":
                            var land = ViewModel.GetObservableCards.Where(x => x.types.Contains("Land"));
                            foreach (var card in land) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "CreatureCheckBox":
                            var creature = ViewModel.GetObservableCards.Where(x => x.types.Contains("Creature"));
                            foreach (var card in creature) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "PlaneswalkerCheckBox":
                            var planeswalker = ViewModel.GetObservableCards.Where(x => x.types.Contains("Planeswalker"));
                            foreach (var card in planeswalker) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "ArtifactCheckBox":
                            var artifact = ViewModel.GetObservableCards.Where(x => x.types.Contains("Artifact"));
                            foreach (var card in artifact) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "InstantCheckBox":
                            var instant = ViewModel.GetObservableCards.Where(x => x.types.Contains("Instant"));
                            foreach (var card in instant) { ViewModel.DisplayCards.Add(card); }
                            break;
                        case "SorceryCheckBox":
                            var sorcery = ViewModel.GetObservableCards.Where(x => x.types.Contains("Land"));
                            foreach (var card in sorcery) { ViewModel.DisplayCards.Add(card); }
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
