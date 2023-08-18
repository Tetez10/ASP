using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            if (HttpContext.Request.Cookies.TryGetValue("LastInteractionTime", out var lastInteractionTime))
            {
                ViewData["LastInteractionTime"] = lastInteractionTime;
            }

            var currentTime = DateTime.Now.ToString();
            Response.Cookies.Append("LastInteractionTime", currentTime);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}