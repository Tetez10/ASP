using ASP.Areas.Identity.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Cookies.TryGetValue("LastInteractionTime", out var lastInteractionTime))
            {
                ViewData["LastInteractionTime"] = lastInteractionTime;
            }

            var currentTime = DateTime.Now.ToString();
            Response.Cookies.Append("LastInteractionTime", currentTime);


            var movies = _dbContext.movies.ToList(); // Récupérez la liste de films depuis la base de données
            return View(movies); // Passez la liste de films à la vue
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
