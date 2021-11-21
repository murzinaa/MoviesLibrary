using MoviesLibrary.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public  interface IFavouriteMovieService
    {
        void AddFavouriteMovie(FavouriteMovie favouriteMovie);
        //avouriteMovie GetByUserId(int userId);
        List<FavouriteMovie> GetByUserId(int userId);
        //void DeleteFavouriteMovie(int id);
        Task DeleteFavouriteMovie(string movie);


    }
}
