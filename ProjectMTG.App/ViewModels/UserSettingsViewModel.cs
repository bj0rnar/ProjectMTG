using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Views;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class UserSettingsViewModel : Observable
    {
        private User _user = ShellViewModel.LoggedInUser;
        public Users _usersDataAccess = new Users();


        public ICommand ChangePassword { get; set; }

        public UserSettingsViewModel()
        {
            ChangePassword = new RelayCommand(ChangeUserPassword);
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
                    ToastCreator.ShowUserToast("Password changed!");
                }
                else
                {
                    ToastCreator.ShowUserToast("No database connection, password was not changed");
                }
            }

        }
    }
}
