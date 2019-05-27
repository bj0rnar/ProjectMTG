using System;
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
		public User User { get; set; }
		
		public ICollection<DeckCards> Cards { get; set; } = new List<DeckCards>();


	}
}
