using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class cinema
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }


        [Display(Name = "Movies")]
        public List<Movie>? movies { get; set; }
        [NotMapped]
        public List<int>? MoviesIds { get; set; }
    }
}
