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
    public class DeckCardsDirectorycs
    {
        static Uri DeckUri = new Uri("http://localhost:61254/api/deckcardsdirs");
        readonly HttpClient _httpClient = new HttpClient();

        internal async Task<bool> AddDeckWithCardsAsync(DeckCardsDir deckWithCards)
        {
            string json = JsonConvert.SerializeObject(deckWithCards);
            HttpResponseMessage result = await _httpClient.PostAsync(DeckUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
