using APIProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Utils;

namespace MoviesLibrary.Web.Controllers
{
    public class TrendingController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;

        public TrendingController(IApiMovieProvider apiMovieProvider)
        {

            _apiMovieProvider = apiMovieProvider;
        }
        public async Task<IActionResult> TrendingMovies()
        {
            return View(await _apiMovieProvider.GetTrendingMovies(Constants.FilmApiUrls.ResturnUrlForTrending()));
        }
    }
}
