using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.BusinessLogic.Utils;
using MoviesLibrary.DataAccess;
using MoviesLibrary.Web.Models;
using MoviesLibrary.Web.ViewModels;
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
        private readonly MovieContext _context;


        public CategoriesController(ILogger<CategoriesController> logger, IApiMovieProvider apiMovieProvider, ICategoriesService categoriesService, ICommentService commentService, MovieContext context)
        {
            _logger = logger;
            _apiMovieProvider = apiMovieProvider;
            _categoriesService = categoriesService;
            _commentService = commentService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Categories");
        }

        public async Task<IActionResult> GetByGenreAction(string genre, int page)
        {
           
            var genreEnum = Convert.ToInt32((Genres)Enum.Parse(typeof(Genres), genre));
            MovieViewModel movieViewModel = new MovieViewModel { Genre = genre, MovieResultVM = await _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(genreEnum, page)) };
            return View("Views/Movie/Movie.cshtml", movieViewModel);

            //return View("Views/Movie/Movie.cshtml", await _categoriesService.GetCategoriesByGenre(FilmApiUrls.ReturnUrl(genreEnum, page)));
        }

        private async Task<IActionResult> ReturnResult(string movie, string view)
        {
            MovieResultViewModel movieResultViewModel = new MovieResultViewModel { MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie)) };
            return View($"{view}", movieResultViewModel);
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

                var favMovies = from fm in _context.FavouriteMovies
                                select fm;


                var favMoviesList = favMovies.Where(fm => fm.UserName.Contains(userEmail) && fm.Title.Contains(movie)).Any();
                if (favMoviesList)
                {
                    return await ReturnResult(movie, "Views/FavMovies/FavouriteMovieResult.cshtml");
                }
                else
                {
                    return await ReturnResult(movie, "Views/Categories/MovieResult.cshtml");
                }
            }

            else
            {
                return await ReturnResult(movie, "Views/Categories/MovieResult.cshtml");
            }

        }

        //[HttpGet]
        //public IActionResult NextPage()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> NextPage(int page, string genre)
        //{
        //    return await GetByGenreAction(genre, page);
        //}

        //[HttpGet]
        //public IActionResult PreviousPage()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> PreviousPage(int page, string genre)
        //{
        //    return await GetByGenreAction(genre, page);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
