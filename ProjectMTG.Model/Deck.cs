using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMTG.Model
{
	public class Deck
	{
		public string DeckName;
		public int DeckId;

		public ICollection<Card> DeckList { get; set; } = new List<Card>();
	}
}
