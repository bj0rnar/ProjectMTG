using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMTG.Model;

namespace ProjectMTG.App.DataAccess
{
    public class Decks
    {
        static Uri DeckUri = new Uri("http://localhost:61254/api/decks");
        readonly HttpClient _httpClient = new HttpClient();

        internal async Task<bool> AddDeckAsync(Deck deck)
        {
            string json = JsonConvert.SerializeObject(deck);
            HttpResponseMessage result = await _httpClient.PostAsync(DeckUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedDeck = JsonConvert.DeserializeObject<Deck>(json);
                deck.DeckId = returnedDeck.DeckId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeleteDeckAsync(Deck deck)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(DeckUri, "decks/" + deck.DeckId));
            return result.IsSuccessStatusCode;
        }


        public async Task<Deck[]> GetUserDecksAsync(int userId)
        {
            var clientResult = await _httpClient.GetAsync(DeckUri);
            var jsonData = await clientResult.Content.ReadAsStringAsync();
            Deck[] decks = JsonConvert.DeserializeObject<Deck[]>(jsonData);

            if (decks.Any(deck => deck.UserId == userId))
            {
                return decks;
            }

            return null;
        }

    }
}
