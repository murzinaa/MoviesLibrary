using APIProviders;
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

namespace MoviesLibrary.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly string apikey = "efc923dfbeb80bd974570be62f1057bc";

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Action()
        {
            //string apikey = "efc923dfbeb80bd974570be62f1057bc";
            int genreID = 28;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));

        }

        public IActionResult Adventure()
        {
            int genreID = 12;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));

        }

        public IActionResult Animation()
        {
            int genreID = 16;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Comedy()
        {
            int genreID = 35;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Crime()
        {
            int genreID = 80;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Drama()
        {
            int genreID = 18;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Documentary()
        {
            int genreID = 99;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Fantasy()
        {
            int genreID = 14;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Horror()
        {
            int genreID = 27;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Romance()
        {

            int genreID = 10749;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Thriller()
        {
            int genreID = 53;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }

        public IActionResult Western()
        {
            int genreID = 37;
            string url = String.Format("https://api.themoviedb.org/3/discover/movie?api_key={0}&with_genres={1}&page=1", apikey, genreID);
            return View("CategoriesResults", API.ProvideAPI(url));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
