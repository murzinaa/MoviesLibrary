using APIProviders;
using BusinessLogic.Interfaces;
using BusinessLogic.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.Models;
using MoviesLibrary.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly ICategoriesService _categoriesService;
        private readonly ICommentService _commentService;


        public CategoriesController(ILogger<CategoriesController> logger, IApiMovieProvider apiMovieProvider, ICategoriesService categoriesService, ICommentService commentService)
        {
            _logger = logger;
            _apiMovieProvider = apiMovieProvider;
            _categoriesService = categoriesService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View("Categories");
        }

        public async Task<IActionResult> GetByGenreAction(string genre)
        {
            var genreEnum = (Genres)Enum.Parse(typeof(Genres), genre);
            return View("Views/Movie/Movie.cshtml", await _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(Convert.ToInt32(genreEnum))));
        }
        


        [HttpGet]
        public IActionResult MovieResult()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieResult(string movie)
        {
            MovieResultViewModel movieResultViewModel = new MovieResultViewModel { MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie)) };
            return View("Views/Categories/MovieResult.cshtml", movieResultViewModel);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
