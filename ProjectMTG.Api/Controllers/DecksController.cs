using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProjectMTG.DataAccess;
using ProjectMTG.Model;
using Remotion.Linq.Clauses;

namespace ProjectMTG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly CollectionContext _context;

        public DecksController(CollectionContext context)
        {
            _context = context;
        }

        // GET: api/Decks
        [HttpGet]
        public IEnumerable<Deck> GetDecks()
        {
            return _context.Decks;
        }

        // GET: api/Decks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deck = await _context.Decks.FindAsync(id);

            if (deck == null)
            {
                return NotFound();
            }

            return Ok(deck);
        }

        // PUT: api/Decks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck([FromRoute] int id, [FromBody] Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deck.DeckId)
            {
                return BadRequest();
            }

            _context.Entry(deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Decks
        [HttpPost]
        public async Task<IActionResult> PostDeck([FromBody] Deck deck)
			{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbUser = (from i in _context.Users
	            where i.UserId == deck.UserId
	            select i).FirstOrDefault();

            Deck dbDeck = new Deck() {User = dbUser};

            foreach (var card in deck.Cards)
            {
	            if (card != null)
	            {
		            var dbCard = (from i in _context.Cards
			            where i.CardId == card.CardId
			            select i).FirstOrDefault();

		            if (dbCard != null)
		            {
			            _context.Entry(dbCard).State = EntityState.Unchanged;
			            dbDeck.Cards.Add(dbCard);
		            }
	            }
            }

            


			/*
            var user = _context.Users.FirstOrDefault(u => u.UserId == deck.UserId);

            if (user != null)
            {
				
            }
			*/

			/*
			if (_context.Users.FirstOrDefault(u => u.UserId == deck.UserId) != null)
			{
				try
				{
				
					var user = (from i in _context.Users
						where deck.UserId == i.UserId
						select i).FirstOrDefault();

					user.Decks.Add(deck);
				

					 _context.Users.FirstOrDefault(u => u.UserId == deck.UserId).Decks.Add(deck);
				}
				catch (NullReferenceException e)
				{
					Debug.WriteLine(e.Message);
				}

			}
			*/
			//           **Egentle dæ som ska skje. Detta funke obviously ikkje**
			//   _context.Users.FirstOrDefault(u => u.UserId == deck.UserId).Decks.Add(deck);



			_context.Decks.Add(dbDeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeck", new { id = deck.DeckId }, deck);
        }

        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deck = await _context.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return Ok(deck);
        }

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(e => e.DeckId == id);
        }
    }
}
