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
    public class RoleGamesController : ControllerBase
    {
        private readonly Contexto _context;

        public RoleGamesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/RoleGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleGame>>> GetRoleGames()
        {
            return await _context.RoleGames.ToListAsync();
        }

        // GET: api/RoleGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleGame>> GetRoleGame(int id)
        {
            var roleGame = await _context.RoleGames.FindAsync(id);

            if (roleGame == null)
            {
                return NotFound();
            }

            return roleGame;
        }

        // PUT: api/RoleGames/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleGame(int id, RoleGame roleGame)
        {
            if (id != roleGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleGameExists(id))
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

        // POST: api/RoleGames
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RoleGame>> PostRoleGame(RoleGame roleGame)
        {
            _context.RoleGames.Add(roleGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleGame", new { id = roleGame.Id }, roleGame);
        }

        // DELETE: api/RoleGames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleGame>> DeleteRoleGame(int id)
        {
            var roleGame = await _context.RoleGames.FindAsync(id);
            if (roleGame == null)
            {
                return NotFound();
            }

            _context.RoleGames.Remove(roleGame);
            await _context.SaveChangesAsync();

            return roleGame;
        }

        private bool RoleGameExists(int id)
        {
            return _context.RoleGames.Any(e => e.Id == id);
        }
    }
}
