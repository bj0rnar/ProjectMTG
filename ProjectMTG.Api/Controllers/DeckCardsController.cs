using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMTG.DataAccess;
using ProjectMTG.Model;

namespace ProjectMTG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckCardsController : ControllerBase
    {
        private readonly CollectionContext _context;

        public DeckCardsController(CollectionContext context)
        {
            _context = context;
        }

        // GET: api/DeckCards
        [HttpGet]
        public IEnumerable<DeckCard> GetDeckCards()
        {
            return _context.DeckCards;
        }

        // GET: api/DeckCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeckCards([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deckCards = await _context.DeckCards.FindAsync(id);

            if (deckCards == null)
            {
                return NotFound();
            }

            return Ok(deckCards);
        }

        // PUT: api/DeckCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeckCards([FromRoute] int id, [FromBody] DeckCard deckCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deckCards.DeckCardId)
            {
                return BadRequest();
            }

            _context.Entry(deckCards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckCardsExists(id))
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

        // POST: api/DeckCards
        [HttpPost]
        public async Task<IActionResult> PostDeckCards([FromBody] DeckCard deckCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeckCards.Add(deckCards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeckCards", new { id = deckCards.DeckCardId }, deckCards);
        }

        // DELETE: api/DeckCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeckCards([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deckCards = await _context.DeckCards.FindAsync(id);
            if (deckCards == null)
            {
                return NotFound();
            }

            _context.DeckCards.Remove(deckCards);
            await _context.SaveChangesAsync();

            return Ok(deckCards);
        }

        private bool DeckCardsExists(int id)
        {
            return _context.DeckCards.Any(e => e.DeckCardId == id);
        }
    }
}