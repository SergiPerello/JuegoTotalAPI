using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuegoTotalApi.Data;
using JuegoTotalApi.Models;

namespace JuegoTotalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayingsController : ControllerBase
    {
        private readonly Contexto _context;

        public PlayingsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Playings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playing>>> GetPlaying()
        {
            return await _context.Playing.ToListAsync();
        }

        // GET: api/Playings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playing>> GetPlaying(int id)
        {
            var playing = await _context.Playing.FindAsync(id);

            if (playing == null)
            {
                return NotFound();
            }

            return playing;
        }

        // PUT: api/Playings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaying(int id, Playing playing)
        {
            if (id != playing.Id)
            {
                return BadRequest();
            }

            _context.Entry(playing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayingExists(id))
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

        // POST: api/Playings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Playing>> PostPlaying(Playing playing)
        {
            _context.Playing.Add(playing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaying", new { id = playing.Id }, playing);
        }

        // DELETE: api/Playings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Playing>> DeletePlaying(int id)
        {
            var playing = await _context.Playing.FindAsync(id);
            if (playing == null)
            {
                return NotFound();
            }

            _context.Playing.Remove(playing);
            await _context.SaveChangesAsync();

            return playing;
        }

        private bool PlayingExists(int id)
        {
            return _context.Playing.Any(e => e.Id == id);
        }
    }
}
