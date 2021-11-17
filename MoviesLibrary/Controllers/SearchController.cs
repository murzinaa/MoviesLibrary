using APIProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Controllers
{
    public class SearchController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly SettingService _settingService;

        public SearchController(IApiMovieProvider apiMovieProvider, SettingService settingService)
        {
            _apiMovieProvider = apiMovieProvider;
            _settingService = settingService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string title)
        {
            return View("Views/Movie/Movie.cshtml", await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(title)));
        }
    }
}
