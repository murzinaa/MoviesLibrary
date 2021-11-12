﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<UserRegistration> _manager;
        private readonly IAPIMovieProvider _apiMovieProvider;
        private readonly MovieContext _context;
        public FavMoviesController(UserManager<UserRegistration> manager, MovieContext context, IAPIMovieProvider apiMovieProvider)
        {
            _manager = manager;
            _context = context;
            _apiMovieProvider = apiMovieProvider;
        }
        public async Task<IActionResult> Favourite()
        {
            ClaimsPrincipal currentUser = User;
            var userEmail= currentUser.FindFirst(ClaimTypes.Email).Value;

            List<FavouriteMovie> result = _context.FavouriteMovies.Where(f => f.UserName == userEmail).ToList();
            //List<List<string>> result1 = new List<List<string>> { };
            List<MovieResultById> result1 = new List<MovieResultById> { };
            foreach (var item in result)
            {
                result1.Add(await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(Convert.ToString(item.Title))));
                //result1.Add(_apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(Convert.ToString(item.Title))));
            }
            return View("Views/FavMovies/Favourite.cshtml", result1);

        }
    }
}
