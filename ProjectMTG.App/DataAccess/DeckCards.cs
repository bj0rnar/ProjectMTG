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
    public class DeckCards
    {
        static Uri _deckcardUri = new Uri("http://localhost:61254/api/deckcards");
        readonly HttpClient _httpClient = new HttpClient();

        internal async Task<bool> AddDeckCardAsync(DeckCard card)
        {
            try
            {
                string json = JsonConvert.SerializeObject(card);
                HttpResponseMessage result = await _httpClient.PostAsync(_deckcardUri, new StringContent(json, Encoding.UTF8, "application/json"));

                return result.IsSuccessStatusCode;

            }
            catch (HttpRequestException ex)
            {
                return false;
                //Logg
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }

        }

        internal async Task<bool> DeleteDeckCardAsync(DeckCard card)
        {
            try
            {
                HttpResponseMessage result =
                    await _httpClient.DeleteAsync(new Uri(_deckcardUri, "deckcards/" + card.DeckCardId));
                return result.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                return false;
                //Logg
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
