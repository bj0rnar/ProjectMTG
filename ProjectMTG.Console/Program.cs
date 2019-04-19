﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using ProjectMTG.Model;
using Newtonsoft.Json.Linq;

namespace ProjectMTG
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine("Jauda");
			loadJson();
		}

		static void loadJson()
		{
			using (StreamReader r = new StreamReader("Standard.json"))
			{
				//String representation of JSON
				string json = r.ReadToEnd();

				var settings = new JsonSerializerSettings();
				settings.CheckAdditionalContent = false;

				var model = JsonConvert.DeserializeObject<Carddata>(json);


				//Linq query, ganske najs?
				var products = from y in model.DOM.cards
							   select y.name;

				var testing = from i in model.DOM.cards
							  from j in model.M19.cards
							  select new { i, j };

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
					Console.WriteLine(x.ToString());
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
