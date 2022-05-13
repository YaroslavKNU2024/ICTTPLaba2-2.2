using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaWebApp.Models;

namespace CinemaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeancesController : Controller
    {
        private readonly CinemaContext _context;

        public SeancesController(CinemaContext context)
        {
            _context = context;
        }

        // GET: api/Seance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seance>>> GetSeance()
        {
            return await _context.Seance.ToListAsync();
        }

        // GET: api/Seance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seance>> GetSeance(int id)
        {
            var seance = await _context.Seance.FindAsync(id);

            if (seance == null)
            {
                return NotFound();
            }

            return seance;
        }

        // PUT: api/seance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeance(int id, Seance seance)
        {
            if (id != seance.Id)
                return BadRequest();

            _context.Entry(seance).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(id))
                    return NotFound();
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Seance
        [HttpPost]
        public async Task<ActionResult<Seance>> PostSeance(Seance seance) {
            _context.Seance.Add(seance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeance", new { id = seance.Id }, seance);
        }

        // DELETE: api/Seance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seance>> DeleteSeance(int id) {
            var seance = await _context.Seance.FindAsync(id);
            if (seance == null)
                return NotFound();

            _context.Seance.Remove(seance);
            await _context.SaveChangesAsync();

            return seance;
        }

        private bool SeanceExists(int id) {
            return _context.Seance.Any(e => e.Id == id);
        }
    }
}