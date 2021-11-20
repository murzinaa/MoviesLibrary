using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;
        public MovieService(MovieContext context)
        {
            _context = context;

        }

        public void EditMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public async Task AddMovie(Movie movie)
        {
            var movies = from m in _context.Movies
                         select m;
            if ((await movies.Where(m => m.Title.Contains(movie.Title)).ToListAsync()).Count == 0)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            //var movies = from m in _context.Users
            //            select m;
            //if ((await movies.Where(u => u.UserName.Contains(movie.Title)).ToListAsync()).Count == 0)
            //{
            //    _context.Movies.Add(movie);
            //    _context.SaveChanges();
            //}
            //_context.Movies.Add(movie);
            //_context.SaveChanges();
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            var result = from m in _context.Movies
                         select m;
            result = result.Where(m => m.Title!.Contains(title));
            return await result.FirstOrDefaultAsync();
            //throw new System.NotImplementedException();
        }

        public async Task<Movie> GetCurrentMovie(Movie movie)
        {
            var movies = from m in _context.Movies
                         select m;
            var moviesList = await movies.Where(m => m.Title.Contains(movie.Title)).ToListAsync();
            if (moviesList.Count == 0)
            {
                await AddMovie(movie);
                return await movies.Where(m => m.Title.Contains(movie.Title)).FirstOrDefaultAsync();
            }
            return moviesList[0];
        } 
    }
}
