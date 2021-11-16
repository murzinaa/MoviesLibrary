using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        Task<Movie> GetMovieByTitle(string title);
        void EditMovie(Movie movie);
        //List<FavouriteMovie> GetByUserId(int userId);
    }
}
