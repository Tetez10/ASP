using ASP.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Data
{
    public class SeedDataContext
    {
        public static async Task<IActionResult> Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
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



                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange
                        (
                            new cinema { Name = "Ugc" },
                            new cinema { Name = "Kinepolis" },
                            new cinema { Name = "OldSchool" }
                        );
                    context.SaveChanges();
                }

                if (!context.movies.Any())
                {
                    context.movies.AddRange
                        (
                            new Movie { name = "Harry potter", description = "Magic Movie", Price = 15 },
                            new Movie { name = "Nemo", description = "Fish Movie", Price = 15 }

                        );
                    context.SaveChanges();
                }

                


                if (!context.actors.Any())
                {
                    context.actors.AddRange
                        (
                            new Actor { FullName = "Johnny Depp", Bio = "Great Actor", profilepictureUrl =  "Randonurl" }
                        );
                    context.SaveChanges();
                }
                return null;


                if (!context.Language.Any())
                {
                    // Initialize the languages
                    context.Language.AddRange
                        (
                            new Language() { Id = "-", Name = "-", Cultures = "", IsShown = false },
                            new Language() { Id = "en", Name = "English", Cultures = "UK;US", IsShown = true },
                            new Language() { Id = "fr", Name = "français", Cultures = "BE;FR", IsShown = true },
                            new Language() { Id = "nl", Name = "Nederlands", Cultures = "BE;NL", IsShown = true }
                        );
                    context.SaveChanges();
                }

                Language.Initialize(context);


            }
            return null;
        }




    }

        }
    


     

