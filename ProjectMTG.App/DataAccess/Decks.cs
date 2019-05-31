using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.DataAccess
{
    public class Decks
    {
        static Uri _deckUri = new Uri("http://localhost:61254/api/decks");
        readonly HttpClient _httpClient = new HttpClient();

        internal async Task<bool> AddDeckAsync(Deck deck)
        {
            try
            {
                string json = JsonConvert.SerializeObject(deck);
                HttpResponseMessage result = await _httpClient.PostAsync(_deckUri, new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(true);

                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("AddDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("AddDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
        }

        internal async Task<bool> DeleteDeckAsync(Deck deck)
        {
            try
            {
                HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(_deckUri, "decks/" + deck.DeckId));
                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("DeleteDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await CustomLogger.Log("DeleteDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("DeleteDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
        }

        internal async Task<bool> EditDeckAsync(Deck deck)
        {
            try
            {
                var json = JsonConvert.SerializeObject(deck);
                HttpResponseMessage result = await _httpClient.PutAsync(new Uri(_deckUri, "decks/" + deck.DeckId),
                    new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(true);
                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("EditDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (JsonReaderException ex)
            {
                await CustomLogger.Log("EditDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("EditDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return false;
            }
        }


        public async Task<Deck[]> GetUserDecksAsync(int userId)
        {
            try
            {
                var clientResult = await _httpClient.GetAsync(_deckUri).ConfigureAwait(true);
                var jsonData = await clientResult.Content.ReadAsStringAsync().ConfigureAwait(true);
                Deck[] decks = JsonConvert.DeserializeObject<Deck[]>(jsonData);

                return decks.Where(x => x.UserId == userId).ToArray();
            }
            catch (HttpRequestException ex)
            {
                await CustomLogger.Log("GetUserDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return null;
                
            }
            catch (ArgumentNullException ex)
            {
                await CustomLogger.Log("GetUserDeckAsync: " + DateTime.Now.ToShortTimeString() + " " + ex.StackTrace).ConfigureAwait(true);
                return null;
            }

        }

    }
}
