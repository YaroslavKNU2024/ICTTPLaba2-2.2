using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Models {
    public class Country {
        public Country() {
            Studio = new HashSet<Studio>();
            Cinema = new HashSet<Cinema>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        [Display(Name = "Країна")]
        public string CountryName { get; set; }

        public virtual ICollection<Studio> Studio { get; set; }
        public virtual ICollection<Cinema> Cinema { get; set; }
    }
}
