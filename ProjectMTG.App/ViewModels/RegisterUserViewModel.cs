using System;
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


        internal async Task<bool> RegisterNewUser(string username, string password)
        {
            User newUser = new User() {UserName = username, Password = password};


            if (await usersDataAccess.AddUser(newUser))
            {
                return true;
            }

            return false;
        }
    }
}
