using System.Collections.Generic;

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
			public Token[] tokens { get; set; }
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
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public Foreigndata[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities legalities { get; set; }
			public string loyalty { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public object[] names { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling[] rulings { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string[] subtypes { get; set; }
			public string[] supertypes { get; set; }
			public int tcgplayerProductId { get; set; }
			public string tcgplayerPurchaseUrl { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string[] types { get; set; }
			public string uuid { get; set; }
			public string uuidV421 { get; set; }
			public string flavorText { get; set; }
			public string power { get; set; }
			public string toughness { get; set; }
			public string watermark { get; set; }
			public string[] variations { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
			public string pauper { get; set; }
			public string penny { get; set; }
		}

		public class Foreigndata
		{
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string flavorText { get; set; }
		}

		public class Ruling
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public string layout { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string power { get; set; }
			public string[] reverseRelated { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string text { get; set; }
			public string toughness { get; set; }
			public string type { get; set; }
			public string uuid { get; set; }
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
			public Token[] tokens { get; set; }
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
			public Token[] tokens { get; set; }
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
			public Token[] tokens { get; set; }
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
			public Token[] tokens { get; set; }
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
			public Token[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		


	}

