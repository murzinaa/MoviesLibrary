using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.APIProviders;
using MoviesLibrary.Web.Models;
using System.Threading.Tasks;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Web.Controllers
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
        public async Task<IActionResult> Search(string movie, int page=1)
        {
            SearchViewModel searchViewModel = new SearchViewModel { MovieTitle = movie, SearchMovieResult = await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(movie, page)) };
            //return View("Views/Search/SearchResult.cshtml", await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(title, page)));
            return View("Views/Search/SearchResult.cshtml", searchViewModel);
            //return View("Views/Movie/Movie.cshtml", await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(title)));
        }
    }
}
