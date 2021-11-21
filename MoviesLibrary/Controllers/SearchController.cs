using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.APIProviders;
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
        public async Task<IActionResult> Search(string title)
        {
            return View("Views/Movie/Movie.cshtml", await _apiMovieProvider.GetMovieList(FilmApiUrls.ReturnUrlForSearch(title)));
        }
    }
}
