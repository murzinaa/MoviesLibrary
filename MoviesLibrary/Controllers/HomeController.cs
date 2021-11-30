using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.Web.Models;
using System.Diagnostics;

namespace MoviesLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        public HomeController(ILogger<CategoriesController> logger)
        {
            _logger = logger;            
        }

        public IActionResult Index()
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
