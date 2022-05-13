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
    public class StudioController : Controller
    {
        private readonly CinemaContext _context;

        public StudioController(CinemaContext context)
        {
            _context = context;
        }

        // GET: api/Studio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudio()
        {
            return await _context.Studio.ToListAsync();
        }

        // GET: api/Studio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id) {
            var studio = await _context.Studio.FindAsync(id);

            if (studio == null)
                return NotFound();

            return studio;
        }

        // PUT: api/Studio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudio(int id, Studio studio) {
            if (id != studio.Id)
                return BadRequest();

            _context.Entry(studio).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Studio
        [HttpPost]
        public async Task<ActionResult<Studio>> PostStudio(Studio studio)
        {
            _context.Studio.Add(studio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudio", new { id = studio.Id }, studio);
        }

        // DELETE: api/Studio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studio>> DeleteStudio(int id) {
            var studio = await _context.Studio.FindAsync(id);
            if (studio == null)
                return NotFound();

            _context.Studio.Remove(studio);
            await _context.SaveChangesAsync();

            return studio;
        }

        private bool StudioExists(int id) {
            return _context.Studio.Any(e => e.Id == id);
        }
    }
}