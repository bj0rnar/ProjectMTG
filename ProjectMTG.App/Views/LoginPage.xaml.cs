using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        private async void Login_OnClick(object sender, RoutedEventArgs e)
        {
            //ConfigureAwait blokkere UI tråden her!!!!!!!
            var userExists = await ViewModel.ValidateUser(UsernameBox.Text, PasswordBox.Password);

            if (userExists != null)
            {
                NavigationService.Navigate(typeof(ShellPage), userExists);
            }
            else
            {
                Debug.WriteLine("X returned false");
            }
        }

        private void NavigateToMain()
        {
            NavigationService.Navigate(typeof(ShellPage));
        }
    }
}
