using ASP.Areas.Identity.Data;
using ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.Data
{
    public class SeedDataContext
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Roles.Any())

                {
                    ApplicationUser newman = new ApplicationUser
                    {
                        Email = "Moatez@test.be",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "Moatez",
                        FirstName = "Moatez",
                        LastName = "gnaoua"
                    };
                    ApplicationUser administrator = new ApplicationUser
                    {
                        Email = "admin@ASP.be",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        UserName = "Administrator",
                        FirstName = "Administrator",
                        LastName = "Admin"
                    };

                    await userManager.CreateAsync(administrator, "Abc!12345");
                    await userManager.CreateAsync(newman, "Abc!12345");

                    context.Roles.AddRange
                    (
                       new IdentityRole { Id = "admin", Name = "admin", NormalizedName = "ADMIN" },
                       new IdentityRole { Id = "user", Name = "user", NormalizedName = "USER" }
                    );
                    context.SaveChanges();
                    context.UserRoles.AddRange
                      (
                          new IdentityUserRole<string> { RoleId = "user", UserId = administrator.Id },
                          new IdentityUserRole<string> { RoleId = "admin", UserId = administrator.Id },
                          new IdentityUserRole<string> { RoleId = "user", UserId = newman.Id }
                      );
                    context.SaveChanges();

                }




                // Ajout des rôles et utilisateurs si nécessaire (comme vous l'avez déjà implémenté)

                // Ajout des cinémas si nécessaire
                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange(
                        new cinema { Name = "Ugc" },
                        new cinema { Name = "Kinepolis" },
                        new cinema { Name = "OldSchool" },
                        new cinema { Name = "New Cinema" },
                        new cinema { Name = "Old Cinema" }

                    );
                    context.SaveChanges();
                }

                // Ajout des acteurs si nécessaire
                if (!context.actors.Any())
                {
                    context.actors.AddRange(
                        new Actor { FullName = "Johnny Depp", Bio = "Great Actor", profilepictureUrl = "RandomUrl" },
                        new Actor { FullName = "Max wells", Bio = "Great Actor", profilepictureUrl = "RandomUrl" },
                        new Actor { FullName = "Waldo Heudens", Bio = "Great Actor", profilepictureUrl = "RandomUrl" },
                        new Actor { FullName = "Moatez Gnaoua", Bio = "Great Actor", profilepictureUrl = "RandomUrl" },
                        new Actor { FullName = "Leonardo Di Caprio", Bio = "Great Actor", profilepictureUrl = "RandomUrl" }

                    );
                    context.SaveChanges();
                }

                // Ajout des films avec relations acteur et cinéma
                if (!context.movies.Any())
                {

                    context.movies.AddRange(

                   new Movie { Name = "Harry Potter", Description = "Magic Movie", Price = 15, ReleaseDate = DateTime.Now.AddDays(7) },
                   new Movie { Name = "Flashback", Description = "Action", Price = 15, ReleaseDate = DateTime.Now.AddDays(14) },
                   new Movie { Name = "Lion king", Description = "Lion Film", Price = 15, ReleaseDate = DateTime.Now.AddDays(15) },
                   new Movie { Name = "Uncharted", Description = "Action", Price = 15, ReleaseDate = DateTime.Now.AddDays(16) },
                   new Movie { Name = "Nemo", Description = "Fish Movie", Price = 15, ReleaseDate = DateTime.Now.AddDays(12) }



                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
