using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class Deck
	{
		[Key]
		public int DeckId { get; set; }
		public string DeckName { get; set; }
		public User User { get; set; }
		
		//For beta purposes. Remove after
		public ICollection<Card> Cards { get; set; } = new List<Card>();
		public ICollection<DeckCardsDir> Contains { get; set; } = new List<DeckCardsDir>();
	}
}
