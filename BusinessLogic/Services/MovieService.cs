using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.DataAccess;

namespace MoviesLibrary.BusinessLogic.Services
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
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            var result = from m in _context.Movies
                         select m;
            result = result.Where(m => m.Title!.Contains(title));
            return await result.FirstOrDefaultAsync();
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
