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
    public class Users
    {
        static Uri UserUri = new Uri("http://localhost:61254/api/users");
        readonly HttpClient _httpClient = new HttpClient();

        public async Task<User[]> GetUsersAsync()
        {
            var clientResult = await _httpClient.GetAsync(UserUri);
            var jsonData = await clientResult.Content.ReadAsStringAsync();
            User[] users = JsonConvert.DeserializeObject<User[]>(jsonData);

            return users;
        }

        internal async Task<bool> AddDeckToUser(Deck deck, int userId)
        {
            string json = JsonConvert.SerializeObject(deck);
            Uri specificUserUri = new Uri(UserUri + "/" + userId + "/?=decks");
            HttpResponseMessage result = await _httpClient.PostAsync(specificUserUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                /*
                json = await result.Content.ReadAsStringAsync();
                var returnedDeck = JsonConvert.DeserializeObject<Deck>(json);
                deck.DeckId = returnedDeck.DeckId;*/
                

                return true;

            }
            else
            {
                return false;
            }
        }

    }



}
