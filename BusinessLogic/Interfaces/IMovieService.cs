using MoviesLibrary.DataAccess.Entities;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        Task AddMovie(Movie movie);
        Task<Movie> GetMovieByTitle(string title);
        void EditMovie(Movie movie);
        //List<FavouriteMovie> GetByUserId(int userId);
        Task<Movie> GetCurrentMovie(Movie movie);
    }
}
