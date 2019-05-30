using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                var clientResult = await _httpClient.GetAsync(_userUri);
                var jsonData = await clientResult.Content.ReadAsStringAsync();
                User[] users = JsonConvert.DeserializeObject<User[]>(jsonData);

                return users;
            }
            catch (HttpRequestException ex)
            {
                return null;
                //Logg
            }
        }

        internal async Task<bool> AddUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpResponseMessage result = await _httpClient.PostAsync(_userUri, new StringContent(json, Encoding.UTF8, "application/json"));
                return result.IsSuccessStatusCode;

            }
            catch (HttpRequestException ex)
            {
                return false;
                //Logg
            }
        }

        internal async Task<bool> ChangePassword(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                HttpResponseMessage result = await _httpClient.PutAsync(new Uri(_userUri, "users/" + user.UserId),  new StringContent(json, Encoding.UTF8, "application/json"));
                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                return false;
                //Logg
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
