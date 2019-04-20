using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class User
	{
		[Key]
		public int UserId;
		public string UserName;
		
		public ICollection<Deck> Decks = new List<Deck>();
		public ICollection<Card> Cards = new List<Card>();
	}
}
