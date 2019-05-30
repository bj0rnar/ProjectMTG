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

    public class LoginViewModel : Observable
    {

        //Get users
        Users _usersDataAccess = new Users();

        

        public LoginViewModel()
        {
        }



        /// <summary>Validates the user with the database</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<User> ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
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
                   
                    return null;
                }
            }
            else
            {
                ToastCreator.ShowUserToast("Input error: No username found");
               
                return null;
            }

        }

       
    }
}
