using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        //List<FavouriteMovie> GetByUserId(int userId);
    }
}
