using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
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

        public async void DeleteFavouriteMovie(int id)
        {
            //List<FavouriteMovie> favouriteMovies = context.FavouriteMovies.AsNoTracking().ToList();
            var result = await context.FavouriteMovies.FindAsync(id);
            context.Remove(result);
            context.SaveChanges();
        }

        public List<FavouriteMovie> GetByUserId(int userId)
        {
            throw new NotImplementedException();
            //return context.Set<FavouriteMovie>().Find(userId);
        }
    }
}
