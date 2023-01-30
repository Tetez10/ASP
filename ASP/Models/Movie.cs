using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
        public double Price { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


    }
}
