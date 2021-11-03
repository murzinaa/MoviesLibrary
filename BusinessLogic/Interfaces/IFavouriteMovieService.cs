using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
   public  interface IFavouriteMovieService
    {
        public FavouriteMovie Create(FavouriteMovie favouriteMovie);
        public FavouriteMovie GetByUserId(int userId);
        // public IEnumerable<FavouriteMovie> GetAll();
    }
}
