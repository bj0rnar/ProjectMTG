using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Query.Expressions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProjectMTG.DataAccess;
using ProjectMTG.Model;

namespace ProjectMTG
{
	public class Program
	{
		static readonly HttpClient httpClient = new HttpClient();
		static Uri cardUri = new Uri("https://mtgjson.com/json/Standard.json");


		static void Main(string[] args)
		{
			//If DB is empty, use these to populate. 
			addToDb();
			CreateDeck();
		}

		public static void CreateDeck()
		{
			using (var db = new CollectionContext())
			{
				User demoUser = new User() {UserName = "Kjellemann", Password = "123"};
				db.Users.Add(demoUser);
				db.SaveChanges();
			}
		}

		//TODO: Do at startup
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



		private static void CheckAllCards()
		{
			//Just a method for verifying json content
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

	}
}
