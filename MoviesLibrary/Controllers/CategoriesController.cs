using APIProviders;
using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Utils;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoviesLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IAPIMovieProvider _apiMovieProvider;
        private readonly ICategoriesService _categoriesService;
        private readonly string apikey = "efc923dfbeb80bd974570be62f1057bc";
        private MovieProvider movieProvider = new MovieProvider();
        private readonly MovieContext db;
        private readonly UserManager<UserRegistration> _manager;

        public CategoriesController(ILogger<CategoriesController> logger, IAPIMovieProvider apiMovieProvider, MovieContext context, ICategoriesService categoriesService, UserManager<UserRegistration> manager)
        {
            _logger = logger;
            _apiMovieProvider = apiMovieProvider;
            _categoriesService = categoriesService;

            db = context;
            _manager = manager;
        }

        public IActionResult Action()
        {
            return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Action))));
        }

        public IActionResult Adventure()
        {
            return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Adventure))));
        }

        public IActionResult Animation()
        {
            return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Animation))));
        }

        public IActionResult Comedy()
        {
            return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Comedy))));
        }

        public IActionResult Crime()
        {
            return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Crime))));
        }

        public IActionResult Drama()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Drama))));
        }

        public IActionResult Documentary()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Documentary))));
        }

        public IActionResult Fantasy()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Fantasy))));
        }

        public IActionResult Horror()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Horror))));
        }

        public IActionResult Romance()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Romance))));
        }

        public IActionResult Thriller()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Thriller))));
        }

        public IActionResult Western()
        {return View("Views/Movie/Movie.cshtml", _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(Genres.Westerm))));
        }


        [HttpGet]
        public IActionResult MovieResult()
        {

            return View();
        }

        [HttpPost]
        public IActionResult MovieResult(string movie)
        {
            return View("Views/Home/Result.cshtml", _apiMovieProvider.GetMovieListById(FilmApiUrls.ReturnUrlForMovieResult(movie)));
        }

        //private async Task<UserRegistration> GetCurrentUser()
        //{
        //    return await _manager.GetUserAsync(HttpContext.User);
        //}

        //    // Generic demo method.
        //    //public async Task DemoMethod()
        //    //{
        //    //    var user = await GetCurrentUser();
        //    //    string userEmail = user.Email; // Here you gets user email 
        //    //    string userId = user.Id;
        //    //}

        [HttpGet]
        public IActionResult AddToFavourite()
        {

            return View();
        }

        [HttpPost]
        public async Task AddToFavourite(string movie)
        {
            //var user = await GetCurrentUser();
            ////int userId = int.Parse(user.Id);

            //var optionsBuilder = new DbContextOptionsBuilder<MovieContext>();

            //var options = optionsBuilder
            //        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MoviesLibrary;Trusted_Connection=True;")
            //        .Options;
            //using (MovieContext db = new MovieContext(options))
            //{
            //    Movie movie1 = new Movie { Title = movie };
            //    //FavouriteMovie favouriteMovie = new FavouriteMovie { MovieId = 1, UserId = 2 };
            //    db.Movies.Add(movie1);
            //    User user1 = new User {UserName = user.UserName, FullName = "vasya Vasya"};
            //    db.Users.Add(user1);
            //    db.SaveChanges();

            //    FavouriteMovie favouriteMovie = new FavouriteMovie {UserId=user1.Id, MovieId=movie1.Id };
                
            //    db.FavouriteMovies.Add(favouriteMovie);

            //    db.SaveChanges();

            //}
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
