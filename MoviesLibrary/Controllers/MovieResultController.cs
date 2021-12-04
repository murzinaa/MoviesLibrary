using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.Web.Helpers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesLibrary.Web.Controllers
{
    public class MovieResultController : Controller
    {
         private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly MoviesHelper _moviesHelper;

        public MovieResultController(ICommentService commentService, IMovieService movieService, IUserService userService, IFavouriteMovieService favouriteMovieService, MoviesHelper moviesHelper)
        {
            _commentService = commentService;
            _movieService = movieService;
            _userService = userService;
            _favouriteMovieService = favouriteMovieService;
            _moviesHelper = moviesHelper;
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

            return View("Views/Shared/MovieResult.cshtml", await  _moviesHelper.GetMovieViewModel(movieTitle, inFavourite: true));

           // return await _moviesHelper(movieTitle, "Views/Shared/MovieResult.cshtml", inFavourite: true);


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
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: isInFavourite));


            //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);

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
            
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: isInFavourite));

            //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(int commentId, string userName, string movie, bool isInFavourite, bool editComment)
        {
            if (GetCurrentUserName() == userName)
            {
                return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: isInFavourite, 
                    editComment: editComment, id: commentId));

                //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite, editComment: editComment, 
                //    id: commentId);

            }
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: isInFavourite));

            //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
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
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: isInFavourite));


            //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite: isInFavourite);
        }

    }
}
