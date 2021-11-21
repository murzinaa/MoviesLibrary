using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.Models;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IApiMovieProvider _apiMovieProvider;

        public CategoriesService(IApiMovieProvider apiMovieProvider)
        {
            _apiMovieProvider = apiMovieProvider;
        }
        public async Task<MovieResult> GetCategoriesByGenre(string url) => await _apiMovieProvider.GetMovieList(url);
    }
}
