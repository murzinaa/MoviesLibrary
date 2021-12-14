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
            _context.FavouriteMovies.Add(favouriteMovie);
            _context.SaveChanges();
        }

        public async Task DeleteFavouriteMovie(string movie)
        {
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


        public List<FavouriteMovie> GetByUserName(string userName)
        {
            List<FavouriteMovie> favouriteMoviesByUserName = _context.FavouriteMovies.Where(f => f.UserName == userName).ToList();
            return favouriteMoviesByUserName;
        }

        public bool GetByUserNameAndMovie(string userName, string movie)
        {
            var favMovies = from fm in _context.FavouriteMovies
                            select fm;

            var favMoviesList = favMovies.Where(fm => fm.UserName.Contains(userName) && fm.Title.Contains(movie)).Any();
            return favMoviesList;
        }
    }
}
