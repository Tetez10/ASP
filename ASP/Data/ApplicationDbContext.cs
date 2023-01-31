using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.Models;

namespace ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASP.Models.Cinema> Cinema { get; set; }
        public DbSet<ASP.Models.Actor> Actor { get; set; }
        public DbSet<ASP.Models.Movie> Movie { get; set; }
    }
}