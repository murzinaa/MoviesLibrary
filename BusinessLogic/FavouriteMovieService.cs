using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class FavouriteMovieService : IFavouriteMovieService
    {
        private readonly MovieContext context;
        public FavouriteMovieService(MovieContext context)
        {
            this.context = context;

        }
        public void AddFavouriteMovie(FavouriteMovie favouriteMovie)
        {
            //var result = context.Add(favouriteMovie);
            context.FavouriteMovies.Add(favouriteMovie);
            context.SaveChanges();
            //return result.Entity;
        }

        public List<FavouriteMovie> GetByUserId(int userId)
        {
            throw new NotImplementedException();
            //return context.Set<FavouriteMovie>().Find(userId);
        }
    }
}
