using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using ProjectMTG.Model;
using Newtonsoft.Json.Linq;
using ProjectMTG.DataAccess;

namespace ProjectMTG
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine("Jauda");
			//LoadJson();
			//AddTest();
			UserTest();
			//CheckAllCards();
		}


		private static void AddStuffToDb()
		{
			
		}

		private static void CheckAllCards()
		{
			using (var r = new StreamReader("Standard.json"))
			{

				var json = r.ReadToEnd();


				var model = JsonConvert.DeserializeObject<Carddata>(json);


				var testing = from i in model.GRN.cards
					select i.names;

				var hopeless = from x in model.M19.cards
					select x.names;

				var allthings = from w in model.DOM.cards
					select w.names;

				var baybay = from s in model.RIX.cards
					select s.names;

				var lattis = from p in model.RNA.cards
					select p.names;

				var jaujau = from k in model.XLN.cards
					select k.names;


				Console.WriteLine("GRN count: " + testing.Count());
				Console.WriteLine("M19 count " + hopeless.Count());
				Console.WriteLine("DOM count " + allthings.Count());
				Console.WriteLine("RIX count " + baybay.Count());
				Console.WriteLine("RNA count " + lattis.Count());
				Console.WriteLine("XLN count " + jaujau.Count());
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
