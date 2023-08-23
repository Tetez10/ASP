using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASP.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
    }
}
