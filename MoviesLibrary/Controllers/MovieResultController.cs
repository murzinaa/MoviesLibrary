using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.Web.Models;
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
        private readonly IMovieService _movieService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly SettingService _settingService;

        public MovieResultController(ILogger<MovieResultController> logger, ICommentService commentService, IMovieService movieService, IUserService userService, IFavouriteMovieService favouriteMovieService, IApiMovieProvider apiMovieProvider, SettingService settingService)
        {
            _logger = logger;
            _commentService = commentService;
            _movieService = movieService;
            _userService = userService;
            _favouriteMovieService = favouriteMovieService;
            _apiMovieProvider = apiMovieProvider;
            _settingService = settingService;
        }
        private async Task<IActionResult> ReturnResult(string movie, string view, bool inFavourite = false, bool editComment = false, int id = 0)
        {
            SharedViewModel sharedViewModel = new SharedViewModel
            {
                MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(),
                ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie, _settingService.ApiKey)),
                EditComment = editComment,
                IsInFavourite = inFavourite,
                CommentId = id
            };
            return View($"{view}", sharedViewModel);
        }


        private string GetCurrentUserName()
        {
            ClaimsPrincipal currentUser = User;
            var userName = currentUser.FindFirst(ClaimTypes.Email).Value;
            return userName;
        }
        [HttpGet]
        public IActionResult AddToFavourite()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavourite(string movieTitle)
        {

            string userName = GetCurrentUserName();

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

            return await ReturnResult(movieTitle, "Views/Shared/MovieResult.cshtml", inFavourite: true);


        }


        [Authorize]
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(string comment, string movie, bool isInFavourite)
        {
            string userEmail = GetCurrentUserName();

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
            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);

        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId, string userName, string movie, bool isInFavourite)
        {
            if (GetCurrentUserName() == userName)
            {
                _commentService.DeleteComment(_commentService.GetById(commentId));
                
            }
            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(int commentId, string userName, string movie, string body, bool isInFavourite, bool editComment)
        {
            if (GetCurrentUserName() == userName)
            {
                return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite, editComment: editComment, 
                    id: commentId);

            }

            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
        }

        [Authorize]
        [HttpGet]
        public IActionResult SaveEditedComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveEditedComment(int commentId, string userName, string movie, string commentBody, bool isInFavourite)
        {
            if (GetCurrentUserName() == userName)
            {
                _commentService.EditComment(commentId, commentBody);
            }

            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
        }

    }
}
