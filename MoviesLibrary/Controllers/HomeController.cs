﻿
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
using static BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Controllers
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
        //public IActionResult Categories()
        //{
        //    return View();
        //}
        
        //public IActionResult Search1()
        //{
        //    return View();
        //}
        //public IActionResult FavouriteMovies()
        //{
        //    return View();

        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Search()
        //{
            
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Search(string title)
        //{
        //    return View("Views/Movie/Movie.cshtml", await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(title)));
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
