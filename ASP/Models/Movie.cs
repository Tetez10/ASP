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

        //Relations
        [Display(Name = "Cinema")]
        public cinema? cinemas { get; set; }
        [NotMapped]
        public int? cinemaId { get;set; }



    }
}
