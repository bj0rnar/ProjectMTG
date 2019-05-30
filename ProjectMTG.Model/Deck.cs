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
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		
		public ICollection<DeckCard> Cards { get; set; } = new List<DeckCard>();


	}
}
