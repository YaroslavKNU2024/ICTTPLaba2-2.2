namespace CinemaWebApp.Models {
    public class Film {
        public Film() {
            FilmStudios = new List<FilmStudioSeance>();
        }
        public int Id { get; set; }
        public string FilmName { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<FilmStudioSeance> FilmStudios { get; set; }

    }
}
