using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
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
