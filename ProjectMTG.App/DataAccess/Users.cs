using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.DataAccess
{
    public class Users
    {
        static Uri _userUri = new Uri("http://localhost:61254/api/users");
        readonly HttpClient _httpClient = new HttpClient();

        public async Task<User[]> GetUsersAsync()
        {
            try
            {
                var clientResult = await _httpClient.GetAsync(_userUri).ConfigureAwait(true);
                var jsonData = await clientResult.Content.ReadAsStringAsync().ConfigureAwait(true);
                var users = JsonConvert.DeserializeObject<User[]>(jsonData);

                return users;
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("GetUserAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return null;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("GetUserAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return null;
            }
        }

        internal async Task<bool> AddUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpResponseMessage result = await _httpClient.PostAsync(_userUri, new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(true);
                return result.IsSuccessStatusCode;

            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("AddUser: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("AddUser: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
        }

        internal async Task<bool> ChangePassword(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                HttpResponseMessage result = await _httpClient.PutAsync(new Uri(_userUri, "users/" + user.UserId), new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(true);
                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("ChangePassword: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (UriFormatException ex)
            {
                await CustomLogger.Log("ChangePassword: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("ChangePassword: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
        }
        
    }
}
