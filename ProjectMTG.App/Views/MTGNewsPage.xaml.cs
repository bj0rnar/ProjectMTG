using System;

using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjectMTG.App.Views
{
    public sealed partial class MTGNewsPage : Page
    {
        public MTGNewsViewModel ViewModel { get; } = new MTGNewsViewModel();

        public MTGNewsPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
