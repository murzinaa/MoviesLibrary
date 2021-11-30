using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MoviesLibrary.BusinessLogic.Utils;
using MoviesLibrary.APIProviders;

namespace MoviesLibrary.Web.Controllers
{
    public class TrendingController : Controller
    {
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly SettingService _settingService;

        public TrendingController(IApiMovieProvider apiMovieProvider, SettingService settingService)
        {

            _apiMovieProvider = apiMovieProvider;
            _settingService = settingService;
        }
        public async Task<IActionResult> TrendingMovies(int page=1)
        {
            return View(await _apiMovieProvider.GetTrendingMovies(Constants.FilmApiUrls.ResturnUrlForTrending(page, _settingService.ApiKey)));
        }
    }
}
