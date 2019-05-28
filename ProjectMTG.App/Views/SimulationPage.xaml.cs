﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Windows.UI.Xaml;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class SimulationPage : Page
    {
        public SimulationViewModel ViewModel { get; } = new SimulationViewModel();


        public SimulationPage()
        {
            InitializeComponent();

            Loaded += SimulationPage_Loaded;
        }

        private async void SimulationPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.LoadDecks();
        }

        private void DeckComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeckComboBox.Items != null)
            {
                var selectedDeck = DeckComboBox.Items[DeckComboBox.SelectedIndex] as Deck;
                ViewModel.DrawNewHand(selectedDeck, 7);
            }
        }

        private void DrawNewHand_OnClick(object sender, RoutedEventArgs e)
        {
            if (DeckComboBox.Items != null)
            {
                var currentDeck = DeckComboBox.Items[DeckComboBox.SelectedIndex] as Deck;
                ViewModel.DrawNewHand(currentDeck, 7);
            }
        }

        private void Mulligan_OnClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.GetDisplayCards.Count > 0)
            {
                if (DeckComboBox.Items != null)
                {
                    var currentDeck = DeckComboBox.Items[DeckComboBox.SelectedIndex] as Deck;
                    ViewModel.DrawNewHand(currentDeck, ViewModel.GetDisplayCards.Count - 1);
                }
            }

        }
    }
}
