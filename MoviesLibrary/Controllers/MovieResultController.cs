using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.Web.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Web.Controllers
{
    public class MovieResultController : Controller
    {
        private readonly ILogger<MovieResultController> _logger;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly MovieContext _context;
        private readonly IMovieService _movieService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly UserManager<UserRegistration> _manager;
        private readonly IApiMovieProvider _apiMovieProvider;

        public MovieResultController(ILogger<MovieResultController> logger, ICommentService commentService, IMovieService movieService, IUserService userService, MovieContext context, IFavouriteMovieService favouriteMovieService, UserManager<UserRegistration> manager, IApiMovieProvider apiMovieProvider)
        {
            _logger = logger;
            _context = context;
            _commentService = commentService;
            _movieService = movieService;
            
            _userService = userService;
            _favouriteMovieService = favouriteMovieService;
            _manager = manager;
            _apiMovieProvider = apiMovieProvider;
        }
        private async Task<IActionResult> ReturnResult(string movie, string view)
        {
            //MovieResultViewModel movieResultViewModel = new MovieResultViewModel { MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), ResultById = await _apiMovieProvider.GetMoviesWithVideos(FilmApiUrls.ReturnUrlForMovieResult(movie)) };

            MovieResultViewModel movieResultViewModel = new MovieResultViewModel
            { 
                MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), 
                ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie)) 
            };
            //return View("Views/Categories/MovieResult.cshtml", movieResultViewModel);
            return View($"{view}", movieResultViewModel);
        }
        //private async Task<UserRegistration> GetCurrentUser()
        //{
        //    return await _manager.GetUserAsync(HttpContext.User);
        //}
        [HttpGet]
        public IActionResult AddToFavourite()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavourite(string movieTitle)
        {
            //var user = await GetCurrentUser();
            //string userName = user.UserName;
            ClaimsPrincipal currentUser = User;
            var userName = currentUser.FindFirst(ClaimTypes.Email).Value;

            User user = new User 
            { 
                UserName = userName 
            };
            user = await _userService.GetCurrentUser(user);

            Movie movie1 = new Movie 
            { 
                Title = movieTitle 
            };
            movie1 = await _movieService.GetCurrentMovie(movie1);

            FavouriteMovie favouriteMovie = new FavouriteMovie 
            {
                UserId = user.Id,
                MovieId = movie1.Id, 
                UserName = user.UserName, 
                Title = movie1.Title 
            };
            _favouriteMovieService.AddFavouriteMovie(favouriteMovie);

            return await ReturnResult(movieTitle, "Views/FavMovies/FavouriteMovieResult.cshtml");
            //MovieResultViewModel movieResultViewModel = new MovieResultViewModel 
            //{ MovieComments = (await _commentService.GetCommentsByMovieTitle(movieTitle)).ToList(), 
            //    ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movieTitle)) 
            //};
            //return View("Views/FavMovies/FavouriteMovieResult.cshtml", movieResultViewModel);

        }

        
        [Authorize]
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(string comment, string movie)
        {
            ClaimsPrincipal currentUser = User;
            var userEmail = currentUser.FindFirst(ClaimTypes.Email).Value;

            User user = new User { UserName = userEmail };
            user = await _userService.GetCurrentUser(user);

            Movie movie1 = new Movie { Title = movie };
            movie1 = await _movieService.GetCurrentMovie(movie1);


            Comment comment1 = new Comment 
            { Body = comment, 
                UserId = user.Id, 
                MovieId = movie1.Id, 
                UserName = userEmail, 
                MovieTitle = movie 
            };

            _commentService.AddComment(comment1);
            return await ReturnResult(movie, "Views/Categories/MovieResult.cshtml");

        }


        //[HttpGet]
        //public IActionResult NextPage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> NextPage(int page)
        //{
        //    return View();

        //}

    }
}
