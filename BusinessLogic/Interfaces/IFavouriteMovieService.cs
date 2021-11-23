using MoviesLibrary.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public  interface IFavouriteMovieService
    {
        void AddFavouriteMovie(FavouriteMovie favouriteMovie);
        Task DeleteFavouriteMovie(string movie);
        List<FavouriteMovie> GetByUserName(string userName);
        bool GetByUserNameAndMovie(string userName, string movie);

    }
}
