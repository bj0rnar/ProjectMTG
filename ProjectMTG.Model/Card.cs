﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectMTG.Model
	{
		
		public class Carddata
		{
			public DOM DOM { get; set; }
			public GRN GRN { get; set; }
			public M19 M19 { get; set; }
			public RIX RIX { get; set; }
			public RNA RNA { get; set; }
			public XLN XLN { get; set; }
		}

		public class DOM
		{
			public int baseSetSize { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card
		{
			[Key]
			public int CardId { get; set; }
			public string artist { get; set; }

			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public string loyalty { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string rarity { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string[] subtype { get; set; }
			public string[] supertype { get; set; }
			public int tcgplayerProductId { get; set; }
			public string tcgplayerPurchaseUrl { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string[] types { get; set; }
			public string uuid { get; set; }
			public string uuidV421 { get; set; }
			public string power { get; set; }
			public string toughness { get; set; }
		
		}
	

		public class GRN
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		

		public class M19
		{
			public int baseSetSize { get; set; }
			public object[] boosterV3 { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		
		
		public class RIX
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		
		public class RNA
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		

		public class XLN
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		


	}

