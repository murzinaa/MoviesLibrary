using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.BusinessLogic.Utils;
using MoviesLibrary.Web.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly ICategoriesService _categoriesService;
        private readonly ICommentService _commentService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly SettingService _settingService;


        public CategoriesController(ILogger<CategoriesController> logger, IFavouriteMovieService favouriteMovieService, IApiMovieProvider apiMovieProvider, ICategoriesService categoriesService, ICommentService commentService, SettingService settingService)
        {
            _logger = logger;
            _apiMovieProvider = apiMovieProvider;
            _categoriesService = categoriesService;
            _commentService = commentService;
            _favouriteMovieService = favouriteMovieService;
            _settingService = settingService;
        }

        private async Task<IActionResult> ReturnResult(string movie, string view, bool inFavourite = false, bool editComment = false)
        {
            SharedViewModel sharedViewModel = new SharedViewModel
            {
                MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(),
                ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie, _settingService.ApiKey)),
                EditComment = editComment,
                IsInFavourite = inFavourite
            };
            return View($"{view}", sharedViewModel);
        }

        public IActionResult Index()
        {
            return View("Categories");
        }

        public async Task<IActionResult> GetByGenreAction(string genre, int page)
        {
           
            var genreEnum = Convert.ToInt32((Genres)Enum.Parse(typeof(Genres), genre));
            MovieViewModel movieViewModel = new MovieViewModel 
            { 
                Genre = genre, 
                MovieResultVM = await _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(genreEnum, page, _settingService.ApiKey)) 
            };
            return View("Views/Categories/Movie.cshtml", movieViewModel);
        }


        [HttpGet]
        public IActionResult MovieResult()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieResult(string movie)
        {
            ClaimsPrincipal currentUser = User;
            if (currentUser.Identity.Name != null)
            {
                var userEmail = currentUser.FindFirst(ClaimTypes.Email).Value;
                if (_favouriteMovieService.GetByUserNameAndMovie(userEmail, movie))
                {
                    return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite:true);
                }
            }
             return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
