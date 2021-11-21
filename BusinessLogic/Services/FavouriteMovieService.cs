using Microsoft.EntityFrameworkCore;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess;
using MoviesLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Services
{
    public class FavouriteMovieService : IFavouriteMovieService
    {
        private readonly MovieContext _context;
        public FavouriteMovieService(MovieContext context)
        {
            _context = context;

        }
        public void AddFavouriteMovie(FavouriteMovie favouriteMovie)
        {
            //var result = context.Add(favouriteMovie);
            _context.FavouriteMovies.Add(favouriteMovie);
            _context.SaveChanges();
            //return result.Entity;
        }

        public async Task DeleteFavouriteMovie(string movie)
        {
            //List<FavouriteMovie> favouriteMovies = context.FavouriteMovies.AsNoTracking().ToList();
            var movies = from m in _context.Movies
                         select m;
            var moviesList = await movies.Where(m => m.Title.Contains(movie)).FirstAsync();

            var favMovies = from fm in _context.FavouriteMovies
                            select fm;
            var favMoviesList = await favMovies.Where(fm => fm.MovieId.Equals(moviesList.Id)).FirstAsync();
            var result = await _context.FavouriteMovies.FindAsync(favMoviesList.Id);
            _context.Remove(result);
            _context.SaveChanges();
        }

        public List<FavouriteMovie> GetByUserId(int userId)
        {
            throw new NotImplementedException();
            //return context.Set<FavouriteMovie>().Find(userId);
        }
    }
}
