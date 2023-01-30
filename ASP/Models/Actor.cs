using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }
        public string profilepictureUrl { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

    }
}
