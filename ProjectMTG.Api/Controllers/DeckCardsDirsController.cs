﻿using System;
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
    public class DeckCardsDirsController : ControllerBase
    {
        private readonly CollectionContext _context;

        public DeckCardsDirsController(CollectionContext context)
        {
            _context = context;
        }

        // GET: api/DeckCardsDirs
        [HttpGet]
        public IEnumerable<DeckCardsDir> GetDeckCardsDirs()
        {
            return _context.DeckCardsDirs;
        }

        // GET: api/DeckCardsDirs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeckCardsDir([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deckCardsDir = await _context.DeckCardsDirs.FindAsync(id);

            if (deckCardsDir == null)
            {
                return NotFound();
            }

            return Ok(deckCardsDir);
        }

        // PUT: api/DeckCardsDirs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeckCardsDir([FromRoute] int id, [FromBody] DeckCardsDir deckCardsDir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deckCardsDir.CardId)
            {
                return BadRequest();
            }

            _context.Entry(deckCardsDir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckCardsDirExists(id))
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

        // POST: api/DeckCardsDirs
        [HttpPost]
        public async Task<IActionResult> PostDeckCardsDir([FromBody] DeckCardsDir deckCardsDir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeckCardsDirs.Add(deckCardsDir);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeckCardsDirExists(deckCardsDir.CardId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeckCardsDir", new { id = deckCardsDir.CardId }, deckCardsDir);
        }

        // DELETE: api/DeckCardsDirs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeckCardsDir([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deckCardsDir = await _context.DeckCardsDirs.FindAsync(id);
            if (deckCardsDir == null)
            {
                return NotFound();
            }

            _context.DeckCardsDirs.Remove(deckCardsDir);
            await _context.SaveChangesAsync();

            return Ok(deckCardsDir);
        }

        private bool DeckCardsDirExists(int id)
        {
            return _context.DeckCardsDirs.Any(e => e.CardId == id);
        }
    }
}
