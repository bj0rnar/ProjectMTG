using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMTG.Model
{
	public class User
	{
		public string UserName;
		public int UserId;

		public ICollection<Deck> DeckLists = new List<Deck>();
	}
}
