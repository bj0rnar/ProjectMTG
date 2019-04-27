using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using ProjectMTG.Model;
using Newtonsoft.Json.Linq;
using ProjectMTG.DataAccess;

namespace ProjectMTG
{
	public class Program
	{
		static readonly HttpClient httpClient = new HttpClient();
		static Uri cardUri = new Uri("https://mtgjson.com/json/Standard.json");


		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine("Jauda");
			//LoadJson();
			//AddTest();
			//UserTest();
			//CheckAllCards();
			//wat();
			//demotest();
			//ImportJsonFromMtgJson();
			//teststuff();
			//addToDb();
			CreateDeck();
		}

		public static void CreateDeck()
		{
			using(var db = new CollectionContext())
			{
				User demoUser = new User() {UserName = "DemoUser"};
				Deck demoDeck = new Deck() {DeckName = "Testdeck", User = demoUser};
				db.Users.Add(demoUser);
				db.Decks.Add(demoDeck);
				db.SaveChanges();
			}
		}

		public static void teststuff()
		{
			using (var db = new CollectionContext())
			{
				using (var r = new StreamReader("Standard.json"))
				{

					var json = r.ReadToEnd();
					var model = JsonConvert.DeserializeObject<Carddata>(json);

					var data = from x in model.DOM.cards
						select x;

					foreach (var q in data)
					{

						db.Cards.Add(new Card()
						{
							name = q.name,
							artist = q.artist,
							colors = q.colors,
							convertedManaCost = q.convertedManaCost,
							manaCost = q.manaCost,
							multiverseId = q.multiverseId,
							loyalty = q.loyalty,
							number = q.number,
							rarity = q.rarity,
							scryfallId = q.scryfallId,
							scryfallIllustrationId = q.scryfallIllustrationId,
							scryfallOracleId = q.scryfallOracleId,
							subtype = q.subtype,
							supertype = q.supertype,
							text = q.text,
							type = q.type,
							types = q.types,
							uuid = q.uuid,
							uuidV421 = q.uuidV421,
							power = q.power,
							toughness = q.toughness


						});

					}
					
					db.SaveChanges();
				}
			}
		}

		public static void addToDb()
		{
			using (var db = new CollectionContext())
			{
				using (var httpclient = new WebClient())
				{
					var jsonData = httpclient.DownloadString("https://mtgjson.com/json/Standard.json");
					var model = JsonConvert.DeserializeObject<Carddata>(jsonData);

					var data = from i in model.GRN.cards
						select i;

					foreach (var q in data)
					{

						db.Cards.Add(new Card()
						{
							name = q.name,
							artist = q.artist,
							colors = q.colors,
							convertedManaCost = q.convertedManaCost,
							manaCost = q.manaCost,
							multiverseId = q.multiverseId,
							loyalty = q.loyalty,
							number = q.number,
							rarity = q.rarity,
							scryfallId = q.scryfallId,
							scryfallIllustrationId = q.scryfallIllustrationId,
							scryfallOracleId = q.scryfallOracleId,
							subtype = q.subtype,
							supertype = q.supertype,
							text = q.text,
							type = q.type,
							types = q.types,
							uuid = q.uuid,
							uuidV421 = q.uuidV421,
							power = q.power,
							toughness = q.toughness


						});
						
						db.SaveChanges();

					}
				}
			}
		}

		public static async Task ImportJsonFromMtgJson()
		{

			using (var r = new StreamReader("Standard.json"))
			{
				using (var db = new CollectionContext())
				{

					//var jsonData = httpclient.DownloadString("https://mtgjson.com/json/Standard.json");

					//var data = JsonConvert.DeserializeObject<Carddata>(jsonData);

					var json = r.ReadToEnd();
					var model = JsonConvert.DeserializeObject<Carddata>(json);

					var data = from x in model.DOM.cards
						select x;

							//var query = from i in data.DOM.cards
						//select i;

					foreach (var card in data)
					{
						db.Cards.Add(card);
						Console.WriteLine("Adding: " + card.name  + " ... ");
					}

					Console.ReadKey();
					db.SaveChanges();
				}

			}


			/*
			using (var db = new CollectionContext())
			{
				HttpResponseMessage result = await httpClient.GetAsync(cardUri);
				string json = await result.Content.ReadAsStringAsync();
				Carddata data = JsonConvert.DeserializeObject<Carddata>(json);

				var query = from i in data.DOM.cards
					select i.name;

				foreach (var card in query)
				{
					Console.WriteLine(card);
				}
			}
			*/
		}

		private static void demotest()
		{
			string json =
				@"{""data"":[{""id"":""518523721"",""name"":""ftyft""}, {""id"":""527032438"",""name"":""ftyftyf""}, {""id"":""527572047"",""name"":""ftgft""}, {""id"":""531141884"",""name"":""ftftft""}]}";

			Friends facebookFriends = JsonConvert.DeserializeObject<Friends>(json);

			foreach (var x in facebookFriends.data)
			{
				Console.WriteLine(x.name);
			}
			Console.ReadKey();
		}

		public class Friends
		{

			public List<FacebookFriend> data { get; set; }
		}

		public class FacebookFriend
		{
			public string name { get; set; }
		}


		private static void wat()
		{
			using (var r = new StreamReader("Standard.json"))
			{
				var json = r.ReadToEnd();



				dynamic data = JsonConvert.DeserializeObject(json);
				IDictionary<string, JToken> cards = data;

				foreach (var card in cards)
				{
					var key = card.Key;
					var value = card.Value;
				}


				Console.ReadKey();

				/*

				var model = JsonConvert.DeserializeObject<Carddata>(json);

				var query = from x in model.DOM.cards
					select x.artist;
				

				foreach (var item in query)
				{
					Console.WriteLine(item);
				}

				Console.ReadKey();
				*/
			}
		}

		private static void CheckAllCards()
		{
			using (var r = new StreamReader("Standard.json"))
			{

				var json = r.ReadToEnd();


				var model = JsonConvert.DeserializeObject<Carddata>(json);


				var testing = from i in model.GRN.cards
					select i.name;

				
				foreach (var i in testing)
				{
					Console.WriteLine(i);
				}
				
				var hopeless = from x in model.M19.cards
					select x.name;

				foreach (String i in hopeless)
				{
					Console.WriteLine(i);
				}

				var allthings = from w in model.DOM.cards
					select w.name;

				foreach (String i in allthings)
				{
					Console.WriteLine(i);
				}


				var baybay = from s in model.RIX.cards
					select s.name;

				foreach (String i in baybay)
				{
					Console.WriteLine(i);
				}

				var lattis = from p in model.RNA.cards
					select p.name;

				foreach (String i in lattis)
				{
					Console.WriteLine(i);
				}

				var jaujau = from k in model.XLN.cards
					select k.name;

				foreach (String i in jaujau)
				{
					Console.WriteLine(i);
				}
				
				Console.ReadKey();
			}
		}

		private static void AddTest()
		{
			using (var r = new StreamReader("Standard.json"))
			{	

				//Not doing it this way :O

				/*
				var json = r.ReadToEnd();
				var model = JsonConvert.DeserializeObject<Carddata>(json);

				var test = from x in model.DOM.cards
					       select x;

				var deck = new Deck();
				

				foreach (var y in test)
				{
					deck.Cards.Add(y);
				}

				Console.WriteLine(deck.Cards.Count);
				Console.ReadKey();
				*/

			}
		}

		private static void UserTest()
		{	
			using (var r = new StreamReader("Standard.json"))
			{
				/*
				var json = r.ReadToEnd();
				var model = JsonConvert.DeserializeObject<Carddata>(json);

				var user = new User();
				var deck = new Deck();

				var modelQuery = from w in model.DOM.cards
								 select w;

				foreach (var q in modelQuery)
				{
					deck.Has.Add(q);					
				}

				user.Decks.Add(deck);

				Console.WriteLine("Users total decks: " + user.Decks.Count);
				Console.WriteLine("Decks total card: " + deck.Cards.Count);
				Console.ReadKey();
				*/

			}
		}

		private static void LoadJson()
		{
			using (var r = new StreamReader("Standard.json"))
			{
				//String representation of JSON
				var json = r.ReadToEnd();

				var settings = new JsonSerializerSettings {CheckAdditionalContent = false};

				var model = JsonConvert.DeserializeObject<Carddata>(json);


				//Linq query, ganske najs?
				var products = from y in model.DOM.cards
							   select y.name;



			    Console.WriteLine(products.ToArray<string>());
				//COUNT FUNKE FAKTISK!!
				Console.WriteLine(products.Count());
				/*
				foreach(var lul in testing)
				{
					Console.WriteLine(lul.i.name.Distinct() + " |||| " + lul.j.name);
				}
				*/

				//ITERER, SHIT WORKS YO!!!

				foreach (var x in products)
				{
					Console.WriteLine(x);
				}

				Console.ReadKey();



				//Console.WriteLine(model.DOM.cards[0].artist.ToString());
				//Console.ReadKey();

				//Eksempel fra timen:
				/**
				 * 
				 * var products = from y in model.DOM.cards
							   select new Card() {Name = y.Name, Id = y.ID }; 
				 *
				 * 
				 * return products.ToArray<Card>();
				 * 
				 */

			}

		}
	}
}
