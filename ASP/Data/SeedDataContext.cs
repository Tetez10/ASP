using Microsoft.EntityFrameworkCore;

namespace ASP.Data
{
    public class SeedDataContext
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (!context.Cinema.Any())
                {
                    context.Cinema.AddRange
                        (
                        new Models.Cinema { Name = "Ugc", description = "Cinema", Logo = "Slogan of society" },
                        new Models.Cinema { Name = "Kinepolis", description = "Cinema", Logo = "Slogan of society" });
                    context.SaveChanges();
                }
                if (!context.Actor.Any())
                {
                    context.Actor.AddRange
                        (
                        new Models.Actor { FullName = " Johnny Depp", Bio = "Great Actor" },
                        new Models.Actor { FullName = " Will Smith", Bio = "Great Actor " });
                    context.SaveChanges();

                }
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange
                        (
                        new Models.Movie { name = "Harry Potter ", description = "Magic Movie", Price = 10 },
                        new Models.Movie { name = "Nemo", description = "Kids Movie", Price = 5 });


                    context.SaveChanges();



                }
            }
        }
    }
}


    
