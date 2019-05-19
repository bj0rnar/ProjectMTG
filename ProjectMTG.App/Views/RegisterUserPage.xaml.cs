using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.App.Services;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    public sealed partial class RegisterUserPage : Page
    {
        public RegisterUserViewModel ViewModel { get; } = new RegisterUserViewModel();

        public RegisterUserPage()
        {
            InitializeComponent();
        }

        private async void Register_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (await ViewModel.RegisterNewUser(UsernameBox.Text, PasswordBox.Password))
            {
                NavigationService.Navigate(typeof(LoginPage));
            }
            else
            {
                Debug.WriteLine("User could not be created");
            }
        }
    }
}
