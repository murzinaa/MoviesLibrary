using MoviesLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesLibrary.APIProviders
{
    public interface IApiMovieProvider
    {
        //Task<MovieResult> GetMoviesList(string url);
        Task<MovieResult> GetMovieList(string url);
        //List<string> GetMovieListById(string url);
        Task<FullMovieResult> GetMoviesListById(string url);
        Task<TrendingMoviesResult> GetTrendingMovies(string url);
        // List<string> GetFavouriteMoviesList(string url);
    }
}
