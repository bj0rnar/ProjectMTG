using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.App.Services;

namespace ProjectMTG.App.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginPage()
        {
            InitializeComponent();

        }

        private void NewUser_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(ShellPage));
        }
    }
}
