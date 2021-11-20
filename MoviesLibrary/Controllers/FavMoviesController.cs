using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities;
using DataAccess;
using System.Security.Claims;
using APIProviders;
using static BusinessLogic.Utils.Constants;
using System;
using MoviesLibrary.Models;
using MoviesLibrary.ViewModels;
using BusinessLogic.Interfaces;

namespace MoviesLibrary.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly ICommentService _commentService;
        private readonly MovieContext _context;
        private readonly IFavouriteMovieService _favouriteMovieService;
        
        public FavMoviesController(MovieContext context, IApiMovieProvider apiMovieProvider, ICommentService commentService, IFavouriteMovieService favouriteMovieService)
        {
            _context = context;
            _apiMovieProvider = apiMovieProvider;
            _commentService = commentService;
            _favouriteMovieService = favouriteMovieService;
        }
        public async Task<IActionResult> Favourite()
        {
            ClaimsPrincipal currentUser = User;
            var userEmail= currentUser.FindFirst(ClaimTypes.Email).Value;

            List<FavouriteMovie> favouriteMoviesByUserName = _context.FavouriteMovies.Where(f => f.UserName == userEmail).ToList();
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
            MovieResultViewModel movieResultViewModel = new MovieResultViewModel { MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie)) };
            return View("Views/FavMovies/FavouriteMovieResult.cshtml", movieResultViewModel);
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
            MovieResultViewModel movieResultViewModel = new MovieResultViewModel { MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(), ResultById = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie)) };
            return View("Views/Categories/MovieResult.cshtml", movieResultViewModel);
        }
    }
}
