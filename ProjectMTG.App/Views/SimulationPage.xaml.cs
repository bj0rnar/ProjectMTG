using System;
using System.Diagnostics;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class SimulationPage : Page
    {
        public SimulationViewModel ViewModel { get; } = new SimulationViewModel();

        public SimulationPage()
        {
            InitializeComponent();
        }

        private void DeckComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDeck = DeckComboBox.Items[DeckComboBox.SelectedIndex] as Deck;
            ViewModel.DrawNewHand(selectedDeck);
        }
    }
}
