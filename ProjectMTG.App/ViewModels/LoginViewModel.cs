using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Services;
using ProjectMTG.App.Views;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public enum LoginAttempts
    {
        UserNotFound,
        WrongPassword,
        NoConnection,
        MissingValues,
        Nothing
    }

    public class LoginViewModel : Observable
    {
        //Get users
        Users _usersDataAccess = new Users();

        public LoginAttempts LoginEnum;

        //Wat to do
        private string _loginStatus;
        public string LoginStatus
        {
            get => _loginStatus;
            set => Set(ref _loginStatus, value);
        }

        public LoginViewModel()
        {
            this.LoginEnum = LoginAttempts.Nothing;
        }

        //TODO: Try catch
        public async Task<User> ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                this.LoginEnum = LoginAttempts.MissingValues;
                ToastCreator.ShowUserToast("Either password or username is missing");
                return null;

            }

            User[] allUsers = null;
            {
                try
                {
                    allUsers = await _usersDataAccess.GetUsersAsync().ConfigureAwait(true);
                }
                catch (HttpRequestException)
                {
                    ToastCreator.ShowUserToast("Could not connect to database");
                    this.LoginEnum = LoginAttempts.NoConnection;
                    
                    return null;
                }
            }

            if (allUsers == null) return null;

            var checkUser = (from x in allUsers
                where x.UserName == username
                select x).FirstOrDefault();

            if (checkUser != null)
            {
                if (checkUser.Password == password)
                {
                    return checkUser;
                }
                else
                {
                    ToastCreator.ShowUserToast("Wrong password");
                    this.LoginEnum = LoginAttempts.WrongPassword;
                   
                    return null;
                }
            }
            else
            {
                ToastCreator.ShowUserToast("No user by that username found");
                this.LoginEnum = LoginAttempts.UserNotFound;
               
                return null;
            }

        }

       
    }
}
