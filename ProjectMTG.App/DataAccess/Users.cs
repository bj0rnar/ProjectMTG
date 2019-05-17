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
        static Uri CardUri = new Uri("http://localhost:61254/api/users");
        readonly HttpClient _httpClient = new HttpClient();

        public async Task<User[]> GetUsersAsync()
        {
            var clientResult = await _httpClient.GetAsync(CardUri);
            var jsonData = await clientResult.Content.ReadAsStringAsync();
            User[] users = JsonConvert.DeserializeObject<User[]>(jsonData);

            return users;
        }

    }



}
