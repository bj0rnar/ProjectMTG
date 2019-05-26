using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class DeckCardsDir
	{
		public int DeckID { get; set; }
		public int CardId { get; set; }
		//public int DuplicateCount { get; set; }

		public virtual Card Card { get; set; }
		public virtual Deck Deck { get; set; }

	}
}
