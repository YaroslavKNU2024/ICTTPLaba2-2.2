using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApp.Models
{
    public class Studio
    {
        public Studio()
        {
            FilmStudioSeance = new HashSet<FilmStudioSeance>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        [Display(Name = "Ім\'я")]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<FilmStudioSeance> FilmStudioSeance { get; set; }
    }
}