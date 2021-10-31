using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIProviders;



namespace MoviesLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IAPIMovieProvider _apiMovieProvider;
        public HomeController(ILogger<CategoriesController> logger, IAPIMovieProvider apiMovieProvider)
        {
            _logger = logger;
            _apiMovieProvider = apiMovieProvider;
            
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Categories()
        {
            return View();
        }
        
        public IActionResult Search1()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Search(string title, bool FindAll)
        {
            string apikey = "efc923dfbeb80bd974570be62f1057bc";
            string url = string.Format("https://api.themoviedb.org/3/search/movie?query={0}&api_key={1}", title, apikey);
            return View("Views/Movie/Movie.cshtml", _apiMovieProvider.GetMovieList(url));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
