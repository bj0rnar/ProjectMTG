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
                ToastCreator.ShowUserToast("Input error: Either name or password is missing");
                return null;

            }

                
            var allUsers = await _usersDataAccess.GetUsersAsync().ConfigureAwait(true);

            //If null, means database caught an exception.
            if (allUsers == null)
            {
                ToastCreator.ShowUserToast("Database connection lost: Cannot validate user");
                return null;
            }

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
                    ToastCreator.ShowUserToast("Input error: Wrong password inserted");
                    this.LoginEnum = LoginAttempts.WrongPassword;
                   
                    return null;
                }
            }
            else
            {
                ToastCreator.ShowUserToast("Input error: No username found");
                this.LoginEnum = LoginAttempts.UserNotFound;
               
                return null;
            }

        }

       
    }
}
