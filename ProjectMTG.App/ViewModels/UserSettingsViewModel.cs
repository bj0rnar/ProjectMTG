using System;
using System.Diagnostics;
using System.Windows.Input;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Services;
using ProjectMTG.App.Views;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class UserSettingsViewModel : Observable
    {
        private User _user = ShellViewModel.LoggedInUser;
        public Users _usersDataAccess = new Users();


        public ICommand ChangePassword { get; set; }
        public ICommand DeleteUser { get; set; }

        public UserSettingsViewModel()
        {
            ChangePassword = new RelayCommand(ChangeUserPassword);
            DeleteUser = new RelayCommand(DeleteCurrentUser);
        }

        private async void ChangeUserPassword()
        {
            ChangePasswordDialog pwDialog = new ChangePasswordDialog();
            await pwDialog.ShowAsync();

            if (pwDialog.Content != null)
            {
                string pw = (string) pwDialog.Content;
                _user.Password = pw;
                if (await _usersDataAccess.ChangePassword(_user))
                {
                    Debug.WriteLine("Change password!");
                }
            }

        }

        private async void DeleteCurrentUser()
        {
            DeleteUserDialog delDialog = new DeleteUserDialog();
            await delDialog.ShowAsync();

            if (delDialog.UserDelete == UserDeleteChoice.Delete)
            {
                Debug.WriteLine("DELETE SELECTED");
                ShellViewModel.LoggedInUser = null;
                NavigationService.Navigate(typeof(LoginPage));
            }
        }
    }
}
