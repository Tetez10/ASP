using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ASP.Models
{
    public class Cinema
    {
        [Key]
        public int id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Movie")]
        public int? MovieId{ get; set; }
        [ForeignKey("MovieId")]
        public List<Movie>? Movie { get; set; }
    }
}
