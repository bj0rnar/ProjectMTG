using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class Deck
	{
		[Key]
		public int DeckId;
		public string DeckName;
		
		//public ICollection<Card> Cards { get; set; } = new List<Card>();
		public ICollection<DeckCardsDir> Has { get; set; } = new List<DeckCardsDir>();
	}
}
