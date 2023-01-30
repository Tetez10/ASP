using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class cinema
    {
        [Key]
        public int id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        //Relations ships
        [ForeignKey("MovieId")]
        public List<Movie> MovieList { get; set; }
        [Display(Name = "Movie")]
        public int? MovieId { get; set; }
    }
}
