﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMTG.Model;

namespace ProjectMTG.App.DataAccess
{
    public class Cards
    {
        static Uri CardUri = new Uri("http://localhost:61254/api/cards");
        readonly HttpClient _httpClient = new HttpClient();

        public async Task<Card[]> GetCardsAsync()
        {
            try
            {
                var clientResult = await _httpClient.GetAsync(CardUri).ConfigureAwait(true);
                var jsonData = await clientResult.Content.ReadAsStringAsync().ConfigureAwait(true);
                Card[] cards = JsonConvert.DeserializeObject<Card[]>(jsonData);

                return cards;
            }
            catch (HttpRequestException ex)
            {
                return null;

            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }

    }
}
