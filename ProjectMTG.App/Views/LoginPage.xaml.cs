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
            NavigationService.Navigate(typeof(RegisterUserPage));
        }

        private async void Login_OnClick(object sender, RoutedEventArgs e)
        {
            //Validate user
            var loginUser = await ViewModel.ValidateUser(UsernameBox.Text, PasswordBox.Password);

            if (loginUser != null)
            {
                //Start shell page, send user
                NavigationService.Navigate(typeof(ShellPage), loginUser);
            }
            else
            {
                Debug.WriteLine("X returned false");
            }
        }

        //???
        private void NavigateToMain()
        {
            NavigationService.Navigate(typeof(ShellPage));
        }
    }
}
