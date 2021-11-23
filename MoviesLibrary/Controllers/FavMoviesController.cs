using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static MoviesLibrary.BusinessLogic.Utils.Constants;
using System;
using MoviesLibrary.Models;
using MoviesLibrary.Web.ViewModels;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.DataAccess;

namespace MoviesLibrary.Web.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly ICommentService _commentService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        
        public FavMoviesController(IApiMovieProvider apiMovieProvider, ICommentService commentService, IFavouriteMovieService favouriteMovieService)
        {
            _apiMovieProvider = apiMovieProvider;
            _commentService = commentService;
            _favouriteMovieService = favouriteMovieService;
        }
        private string GetCurrentUserName()
        {
            ClaimsPrincipal currentUser = User;
            var userName = currentUser.FindFirst(ClaimTypes.Email).Value;
            return userName;
        }
        private async Task<IActionResult> ReturnResult(string movie, string view)
        {
            MovieResultViewModel movieResultViewModel = new MovieResultViewModel
            {
                MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(),
                ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie))
            };
            return View($"{view}", movieResultViewModel);
        }

        public async Task<IActionResult> Favourite()
        {
            ClaimsPrincipal currentUser = User;
            var userEmail= currentUser.FindFirst(ClaimTypes.Email).Value;

            List<FavouriteMovie> favouriteMoviesByUserName = _favouriteMovieService.GetByUserName(userEmail);
            List<FullMovieResult> listOfFavouriteMovies = new List<FullMovieResult> { };
            foreach (var item in favouriteMoviesByUserName)
            {
                listOfFavouriteMovies.Add(await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(Convert.ToString(item.Title))));
            }
            return View("Views/FavMovies/Favourite.cshtml", listOfFavouriteMovies);

        }

        [HttpGet]
        public IActionResult FavouriteMovieResult()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FavouriteMovieResult(string movie)
        {
            return await ReturnResult(movie, "Views/FavMovies/FavouriteMovieResult.cshtml");
        }

        [HttpGet]
        public IActionResult RemoveFromFavourite()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavourite(string movie)
        {
            await _favouriteMovieService.DeleteFavouriteMovie(movie);
            return await ReturnResult(movie, "Views/Categories/MovieResult.cshtml");
        }

        public IActionResult DeleteComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId, string userName, string movie)
        {
            if (GetCurrentUserName() == userName)
            {
                _commentService.DeleteComment(_commentService.GetById(commentId));

            }
            return await ReturnResult(movie, "Views/FavMovies/FavouriteMovieResult.cshtml");
            //return RedirectToAction("Index", "Home");
        }
    }
}
