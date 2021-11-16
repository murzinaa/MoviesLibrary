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
using APIProviders.MovResultById;

namespace MoviesLibrary.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        private readonly IAPIMovieProvider _apiMovieProvider;
        private readonly MovieContext _context;
        public FavMoviesController(MovieContext context, IAPIMovieProvider apiMovieProvider)
        {
            _context = context;
            _apiMovieProvider = apiMovieProvider;
        }
        public async Task<IActionResult> Favourite()
        {
            ClaimsPrincipal currentUser = User;
            var userEmail= currentUser.FindFirst(ClaimTypes.Email).Value;

            List<FavouriteMovie> favouriteMoviesByUserName = _context.FavouriteMovies.Where(f => f.UserName == userEmail).ToList();
            List<MovieResultById> listOfFavouriteMovies = new List<MovieResultById> { };
            foreach (var item in favouriteMoviesByUserName)
            {
                listOfFavouriteMovies.Add(await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(Convert.ToString(item.Title))));
            }
            return View("Views/FavMovies/Favourite.cshtml", listOfFavouriteMovies);

        }
    }
}
