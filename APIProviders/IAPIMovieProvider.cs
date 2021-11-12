using APIProviders.MovResultById;
using MoviesLibrary.Models;
using System.Threading.Tasks;

namespace APIProviders
{
    public interface IAPIMovieProvider
    {
        //Task<MovieResult> GetMoviesList(string url);
        Task<MovieResult> GetMovieList(string url);
        //List<string> GetMovieListById(string url);
        Task<MovieResultById> GetMoviesListById(string url);
       // List<string> GetFavouriteMoviesList(string url);
    }
}
