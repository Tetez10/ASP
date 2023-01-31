using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
        public double Price { get; set; }

        [Display(Name = "Actor")]
        public int? ActorId { get; set; }
        [ForeignKey("ActorId")]
        public List<Actor>? Actors { get; set; }
    }
}
