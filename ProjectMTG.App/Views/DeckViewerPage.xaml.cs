using System;

using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class DeckViewerPage : Page
    {
        public DeckViewerViewModel ViewModel { get; } = new DeckViewerViewModel();

        public DeckViewerPage()
        {
            InitializeComponent();

            //Loaded += DeckViewerPage_Loaded;
        }

        private async void DeckViewerPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.GetUserDecks();
        }


        private async void DeckLW_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedDeck = (Deck) e.ClickedItem;
            await ViewModel.LoadImages(selectedDeck);
        }
    }
}
