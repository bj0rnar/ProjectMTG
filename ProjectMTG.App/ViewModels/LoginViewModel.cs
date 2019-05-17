using System;
using System.Diagnostics;
using System.Linq;
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

        Users usersDataAccess = new Users();

        public LoginViewModel()
        {

        }


        public async Task<User> ValidateUser(string username, string password)
        {
            var allUsers = await usersDataAccess.GetUsersAsync().ConfigureAwait(false);

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
                    Debug.WriteLine("Wrong password");
                    return null;
                }
            }
            else
            {
                Debug.WriteLine("No user by that username");
                return null;
            }
            
        }
    }
}
