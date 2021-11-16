using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesLibrary.Controllers
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

        public MovieResultController(ILogger<MovieResultController> logger, ICommentService commentService, IMovieService movieService, IUserService userService, MovieContext context, IFavouriteMovieService favouriteMovieService, UserManager<UserRegistration> manager)
        {
            _logger = logger;
            _commentService = commentService;
            _movieService = movieService;
            _context = context;
            _userService = userService;
            _favouriteMovieService = favouriteMovieService;
            _manager = manager; 
        }
        //public IActionResult MovieResult()
        //{

        //    return View();
        //}
        private async Task<UserRegistration> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }
        [HttpGet]
        public IActionResult AddToFavourite()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavourite(string movie)
        {
            var user = await GetCurrentUser();
            string userName = user.UserName;
            User user1 = new User { UserName = userName };
            _userService.AddUser(user1);
            Movie movie1 = new Movie { Title = movie };
            _movieService.AddMovie(movie1);
            FavouriteMovie favouriteMovie = new FavouriteMovie { UserId = user1.Id, MovieId = movie1.Id, UserName = user1.UserName, Title = movie1.Title, Movie = movie1, User = user1 };
            _favouriteMovieService.AddFavouriteMovie(favouriteMovie);
            return RedirectToAction();
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task AddComment(string comment, string movie)
        {
            ClaimsPrincipal currentUser = User;
            var userEmail = currentUser.FindFirst(ClaimTypes.Email).Value;

            var result = from m in _context.Movies
                         select m;
            result = result.Where(m => m.Title!.Contains(movie));
            var result_1 = await result.ToListAsync();


            var result1 = from u in _context.Users
                          select u;
            result1 = result1.Where(u => u.UserName.Contains(userEmail));
            var result1_1 = await result1.ToListAsync();


            if (result_1.Count == 0)
            {
                Movie movie1 = new Movie { Title = movie };
                _movieService.AddMovie(movie1);
                if (result1_1.Count == 0)
                {
                    User user = new User { UserName = userEmail };
                    _userService.AddUser(user);
                    Comment comment1 = new Comment { Body = comment, UserName = userEmail, UserId = user.Id, MovieId = movie1.Id };
                    _commentService.AddComment(comment1);
                }
                else
                {
                    Comment comment1 = new Comment { Body = comment, UserName = userEmail, UserId = result1_1[0].Id, MovieId = movie1.Id };
                    _commentService.AddComment(comment1);
                }
            }
            else if (result1_1.Count == 0 && result_1.Count >= 0)
            {
                User user = new User { UserName = userEmail };
                _userService.AddUser(user);
                Comment comment1 = new Comment { Body = comment, UserName = userEmail, UserId = user.Id, MovieId = result_1[0].Id };
                _commentService.AddComment(comment1);
            }
            else if (result_1.Count >= 0 && result1_1.Count >= 0)
            {
                Comment comment1 = new Comment { Body = comment, UserName = userEmail, UserId = result1_1[0].Id, MovieId = result_1[0].Id };
                _commentService.AddComment(comment1);
            }
        }

    }
}
