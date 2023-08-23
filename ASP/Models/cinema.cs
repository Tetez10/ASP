using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class cinema
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

    }
}
