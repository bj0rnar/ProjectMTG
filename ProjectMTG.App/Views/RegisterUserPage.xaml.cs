using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.App.Helpers;
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
            //Registration complete, navigate back to loginpage
            if (await ViewModel.RegisterNewUser(UsernameBox.Text, PasswordBox.Password))
            {
                NavigationService.Navigate(typeof(LoginPage));
            }
            else
            {
                ToastCreator.ShowUserToast("ERROR: User could not be created");
            }
        }
    }
}
