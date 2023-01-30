using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class cinema
    {
        [Key]
        public int id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}
