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
using MoviesLibrary.Web.Helpers;

namespace MoviesLibrary.Web.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly IFavouriteMovieService _favouriteMovieService;
        private readonly SettingService _settingService;
        private readonly MoviesHelper _moviesHelper;

        public FavMoviesController(IApiMovieProvider apiMovieProvider, IFavouriteMovieService favouriteMovieService, SettingService settingService, MoviesHelper moviesHelper)
        {
            _apiMovieProvider = apiMovieProvider;
            _favouriteMovieService = favouriteMovieService;
            _settingService = settingService;
            _moviesHelper = moviesHelper;
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
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie, inFavourite: true));

            // return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml", inFavourite:true);
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
            return View("Views/Shared/MovieResult.cshtml", await _moviesHelper.GetMovieViewModel(movie));

            //return await ReturnResult(movie, "Views/Shared/MovieResult.cshtml");
        }

    }
}
