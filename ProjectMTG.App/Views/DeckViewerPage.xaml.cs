using System;

using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjectMTG.App.Views
{
    public sealed partial class DeckViewerPage : Page
    {
        public DeckViewerViewModel ViewModel { get; } = new DeckViewerViewModel();

        public DeckViewerPage()
        {
            InitializeComponent();
        }
    }
}
