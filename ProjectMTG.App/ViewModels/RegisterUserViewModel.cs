using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjectMTG.App.DataAccess;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class RegisterUserViewModel : Observable
    {
        public Users usersDataAccess = new Users();

        public RegisterUserViewModel()
        {

        }

        /// <summary>Registers the new user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        internal async Task<bool> RegisterNewUser(string username, string password)
        {
            if (ValidateUserInput(username, password))
            {
                User newUser = new User() {UserName = username, Password = password};

                if (await usersDataAccess.AddUser(newUser))
                {
                    return true;
                }
                else
                {
                    ToastCreator.ShowUserToast("Lost connection with database, can't add user");
                    return false;
                }
            }
            else
            {
                ToastCreator.ShowUserToast("Invalid username or password");
                return false;
            }
          
        }

        /// <summary>Validates the user input.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private bool ValidateUserInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return (username.Length < 16) && (password.Length < 16);
        }
    }
}
