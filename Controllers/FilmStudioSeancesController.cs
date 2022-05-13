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
    public class FilmStudioSeancesController : Controller
    {
        private readonly CinemaContext _context;

        public FilmStudioSeancesController(CinemaContext context) {
            _context = context;
        }

        // GET: api/GetFilmStudioSeance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmStudioSeance>>> GetFilmStudioSeance() {
            return await _context.FilmStudioSeance.ToListAsync();
        }

        // GET: api/SongArtistConcerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmStudioSeance>> GetGetFilmStudioSeance(int id)
        {
            var filmStudioSeance = await _context.FilmStudioSeance.FindAsync(id);

            if (filmStudioSeance == null)
                return NotFound();

            return filmStudioSeance;
        }

        // PUT: api/SongArtistConcerts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmStudioSeance(int id, FilmStudioSeance filmStudioSeance) {
            if (id != filmStudioSeance.Id)
                return BadRequest();

            _context.Entry(filmStudioSeance).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!FilmStudioSeanceExists(id))
                    return NotFound();
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/filmStudioSeance
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FilmStudioSeance>> PostFilmStudioSeance(FilmStudioSeance filmStudioSeance)
        {
            _context.FilmStudioSeance.Add(filmStudioSeance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmStudioSeance", new { id = filmStudioSeance.Id }, filmStudioSeance);
        }

        // DELETE: api/filmStudioSeance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmStudioSeance>> DeleteFilmStudioSeance(int id)
        {
            var filmStudioSeance = await _context.FilmStudioSeance.FindAsync(id);
            if (filmStudioSeance == null)
            {
                return NotFound();
            }

            _context.FilmStudioSeance.Remove(filmStudioSeance);
            await _context.SaveChangesAsync();

            return filmStudioSeance;
        }

        private bool FilmStudioSeanceExists(int id) {
            return _context.FilmStudioSeance.Any(e => e.Id == id);
        }
    }
}