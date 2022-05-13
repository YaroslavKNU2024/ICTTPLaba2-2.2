using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models
{
    public class CinemaContext: DbContext
    {
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<Seance> Seance { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmStudioSeance> FilmStudioSeance { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
