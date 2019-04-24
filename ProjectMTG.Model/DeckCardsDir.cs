using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMTG.Model
{
	public class DeckCardsDir
	{
		public int DeckId { get; set; }
		public Deck Deck { get; set; }
		public int CardId { get; set; }
		public Card Card { get; set; }
	}
}
