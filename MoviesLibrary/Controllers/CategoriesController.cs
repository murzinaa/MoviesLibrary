using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.BusinessLogic.Utils;
using MoviesLibrary.Web.Helpers;
using MoviesLibrary.Web.Models;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly SettingService _settingService;
        private readonly MoviesHelper _moviesHelper;


        public CategoriesController(IFavouriteMovieService favouriteMovieService, ICategoriesService categoriesService, SettingService settingService, MoviesHelper moviesHelper)
        {
            _categoriesService = categoriesService;
            _favouriteMovieService = favouriteMovieService;
            _settingService = settingService;
            _moviesHelper = moviesHelper;
        }


        public IActionResult Index()
        {
            return View("Categories");
        }

        public async Task<IActionResult> GetByGenre(string genre, int page)
        {
           
            var genreEnum = Convert.ToInt32((Genres)Enum.Parse(typeof(Genres), genre));

            GenreViewModel genreViewModel = new GenreViewModel 
            { 
                Genre = genre, 
                MovieResultVM = await _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(genreEnum, page, _settingService.ApiKey)) 
            };

            return View("Views/Categories/CategoriesResult.cshtml", genreViewModel);
        }


        [HttpGet]
        public IActionResult MovieResult()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieResult(string movie)
        {
            const string view = "Views/Shared/MovieResult.cshtml";
            ClaimsPrincipal currentUser = User;
            if (currentUser.Identity.Name != null)
            {
                var userEmail = currentUser.FindFirst(ClaimTypes.Email).Value;

                if (_favouriteMovieService.GetByUserNameAndMovie(userEmail, movie))
                {
                    return View(view, await _moviesHelper.GetMovieViewModel(movie, userEmail, inFavourite: true));
                }
            }

            return View(view, await _moviesHelper.GetMovieViewModel(movie, null));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
