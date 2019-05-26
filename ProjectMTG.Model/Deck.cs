using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class Deck
	{
		public int DeckId { get; set; }
		public string DeckName { get; set; }
		public User user { get; set; }

		public virtual ICollection<DeckCardsDir> Cards { get; set; } = new List<DeckCardsDir>();
	}
}
