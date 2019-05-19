using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectMTG.Model
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		
		public ICollection<Deck> Decks { get; set; } = new List<Deck>();
	}
}
