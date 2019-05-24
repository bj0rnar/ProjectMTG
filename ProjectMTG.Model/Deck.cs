﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectMTG.Model
{
	public class Deck
	{	
		[Key]
		public int DeckId { get; set; }
		public string DeckName { get; set; }
		//public int UserId { get; set; }
		public User User { get; set; }
		
		public ICollection<Card> Cards { get; set; } = new List<Card>();

		//public virtual ICollection<DeckWithCards> DeckCards { get; set; } = new List<DeckWithCards>();

	}
}
