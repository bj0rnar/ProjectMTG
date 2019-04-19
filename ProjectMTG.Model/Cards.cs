using System.Collections.Generic;

namespace ProjectMTG.Model
	{
		public class Completelist
		{
			public List<Carddata> cards { get; set; }
		}

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
			public Card1[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta1 meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public Token1[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta1
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card1
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public string flavorText { get; set; }
			public Foreigndata1[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities1 legalities { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string power { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling1[] rulings { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string[] subtypes { get; set; }
			public string[] supertypes { get; set; }
			public int tcgplayerProductId { get; set; }
			public string tcgplayerPurchaseUrl { get; set; }
			public string text { get; set; }
			public string toughness { get; set; }
			public string type { get; set; }
			public string[] types { get; set; }
			public string uuid { get; set; }
			public string uuidV421 { get; set; }
			public string watermark { get; set; }
			public string[] names { get; set; }
			public string loyalty { get; set; }
			public float faceConvertedManaCost { get; set; }
			public string side { get; set; }
			public string[] variations { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities1
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string pauper { get; set; }
			public string penny { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
		}

		public class Foreigndata1
		{
			public string flavorText { get; set; }
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
		}

		public class Ruling1
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token1
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
			public string watermark { get; set; }
		}

		public class M19
		{
			public int baseSetSize { get; set; }
			public object[] boosterV3 { get; set; }
			public Card2[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta2 meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public Token2[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta2
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card2
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public string flavorText { get; set; }
			public Foreigndata2[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities2 legalities { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling2[] rulings { get; set; }
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
			public string power { get; set; }
			public string toughness { get; set; }
			public string loyalty { get; set; }
			public string[] names { get; set; }
			public string[] colorIndicator { get; set; }
			public float faceConvertedManaCost { get; set; }
			public string frameEffect { get; set; }
			public string side { get; set; }
			public string[] variations { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities2
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
			public string penny { get; set; }
			public string pauper { get; set; }
		}

		public class Foreigndata2
		{
			public string flavorText { get; set; }
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
		}

		public class Ruling2
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token2
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

		public class RIX
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card3[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta3 meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public Token3[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta3
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card3
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public Foreigndata3[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities3 legalities { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string[] names { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling3[] rulings { get; set; }
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
			public string power { get; set; }
			public string toughness { get; set; }
			public string flavorText { get; set; }
			public string watermark { get; set; }
			public string loyalty { get; set; }
			public float faceConvertedManaCost { get; set; }
			public string frameEffect { get; set; }
			public string side { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities3
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string penny { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
			public string pauper { get; set; }
		}

		public class Foreigndata3
		{
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string flavorText { get; set; }
		}

		public class Ruling3
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token3
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

		public class RNA
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card4[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta4 meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public Token4[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta4
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card4
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public Foreigndata4[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities4 legalities { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string power { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling4[] rulings { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string[] subtypes { get; set; }
			public string[] supertypes { get; set; }
			public int tcgplayerProductId { get; set; }
			public string tcgplayerPurchaseUrl { get; set; }
			public string text { get; set; }
			public string toughness { get; set; }
			public string type { get; set; }
			public string[] types { get; set; }
			public string uuid { get; set; }
			public string uuidV421 { get; set; }
			public string flavorText { get; set; }
			public string watermark { get; set; }
			public string loyalty { get; set; }
			public float faceConvertedManaCost { get; set; }
			public string[] names { get; set; }
			public string side { get; set; }
			public string[] variations { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities4
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
			public string penny { get; set; }
			public string pauper { get; set; }
		}

		public class Foreigndata4
		{
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string flavorText { get; set; }
		}

		public class Ruling4
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token4
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
			public string toughness { get; set; }
			public string type { get; set; }
			public string uuid { get; set; }
			public string text { get; set; }
			public string watermark { get; set; }
		}

		public class XLN
		{
			public int baseSetSize { get; set; }
			public string block { get; set; }
			public object[] boosterV3 { get; set; }
			public Card5[] cards { get; set; }
			public string code { get; set; }
			public bool isFoilOnly { get; set; }
			public bool isOnlineOnly { get; set; }
			public Meta5 meta { get; set; }
			public string mtgoCode { get; set; }
			public string name { get; set; }
			public string releaseDate { get; set; }
			public int tcgplayerGroupId { get; set; }
			public Token5[] tokens { get; set; }
			public int totalSetSize { get; set; }
			public string type { get; set; }
		}

		public class Meta5
		{
			public string date { get; set; }
			public string version { get; set; }
		}

		public class Card5
		{
			public string artist { get; set; }
			public string borderColor { get; set; }
			public string[] colorIdentity { get; set; }
			public string[] colors { get; set; }
			public float convertedManaCost { get; set; }
			public Foreigndata5[] foreignData { get; set; }
			public string frameVersion { get; set; }
			public bool hasFoil { get; set; }
			public bool hasNonFoil { get; set; }
			public string layout { get; set; }
			public Legalities5 legalities { get; set; }
			public string manaCost { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string number { get; set; }
			public string originalText { get; set; }
			public string originalType { get; set; }
			public string power { get; set; }
			public string[] printings { get; set; }
			public string rarity { get; set; }
			public Ruling5[] rulings { get; set; }
			public string scryfallId { get; set; }
			public string scryfallIllustrationId { get; set; }
			public string scryfallOracleId { get; set; }
			public string[] subtypes { get; set; }
			public string[] supertypes { get; set; }
			public int tcgplayerProductId { get; set; }
			public string tcgplayerPurchaseUrl { get; set; }
			public string text { get; set; }
			public string toughness { get; set; }
			public string type { get; set; }
			public string[] types { get; set; }
			public string uuid { get; set; }
			public string uuidV421 { get; set; }
			public string flavorText { get; set; }
			public string watermark { get; set; }
			public float faceConvertedManaCost { get; set; }
			public string frameEffect { get; set; }
			public string[] names { get; set; }
			public string side { get; set; }
			public string loyalty { get; set; }
			public string[] variations { get; set; }
			public bool isStarter { get; set; }
		}

		public class Legalities5
		{
			public string commander { get; set; }
			public string duel { get; set; }
			public string frontier { get; set; }
			public string future { get; set; }
			public string legacy { get; set; }
			public string modern { get; set; }
			public string standard { get; set; }
			public string vintage { get; set; }
			public string penny { get; set; }
			public string pauper { get; set; }
		}

		public class Foreigndata5
		{
			public string language { get; set; }
			public int multiverseId { get; set; }
			public string name { get; set; }
			public string text { get; set; }
			public string type { get; set; }
			public string flavorText { get; set; }
		}

		public class Ruling5
		{
			public string date { get; set; }
			public string text { get; set; }
		}

		public class Token5
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


	}

