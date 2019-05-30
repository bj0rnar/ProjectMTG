using System;
using System.Diagnostics;
using System.Net.Http;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{

    public sealed partial class DeckViewerPage : Page
    {
        public DeckViewerViewModel ViewModel { get; } = new DeckViewerViewModel();

        public DeckViewerPage()
        {
            InitializeComponent();

            Loaded += DeckViewerPage_Loaded;
        }

        private async void DeckViewerPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                await ViewModel.GetUserDecks().ConfigureAwait(true);
            }
            catch (HttpRequestException ex)
            {
                ToastCreator.ShowUserToast("Could not load decks");
            }
            catch (JsonReaderException ex)
            {
                ToastCreator.ShowUserToast("Could not read data from database");
            }
        }


        private async void DeckLW_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedDeck = (Deck) e.ClickedItem;
            Debug.WriteLine(selectedDeck.Cards.Count);
            await ViewModel.LoadImages(selectedDeck).ConfigureAwait(true);
        }
    }
}
