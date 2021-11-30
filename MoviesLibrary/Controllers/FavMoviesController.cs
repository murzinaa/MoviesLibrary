using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static MoviesLibrary.BusinessLogic.Utils.Constants;
using System;
using MoviesLibrary.Models;
using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.Web.Models;

namespace MoviesLibrary.Web.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly ICommentService _commentService;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly SettingService _settingService;

        public FavMoviesController(IApiMovieProvider apiMovieProvider, ICommentService commentService, IFavouriteMovieService favouriteMovieService, SettingService settingService)
        {
            _apiMovieProvider = apiMovieProvider;
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
        public async Task<IActionResult> Favourite()
        {
            ClaimsPrincipal currentUser = User;
            var userEmail= currentUser.FindFirst(ClaimTypes.Email).Value;

            List<FavouriteMovie> favouriteMoviesByUserName = _favouriteMovieService.GetByUserName(userEmail);
            List<FullMovieResult> listOfFavouriteMovies = new List<FullMovieResult> { };
            foreach (var item in favouriteMoviesByUserName)
            {
                listOfFavouriteMovies.Add(await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(Convert.ToString(item.Title), _settingService.ApiKey)));
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
            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite:true);
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
            return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml");
        }

    }
}
