using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectMTG.Model
{
	[Table("DeckCard")]
	public class DeckCard
	{
		[Key]
		public int DeckCardId { get; set; }
		[ForeignKey("DeckId")]
		public int DeckId { get; set; }

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
}
