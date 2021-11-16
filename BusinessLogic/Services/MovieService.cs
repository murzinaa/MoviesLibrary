using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Security.Claims;
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

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            var result = from m in _context.Movies
                         select m;
            result = result.Where(m => m.Title!.Contains(title));
            return await result.FirstOrDefaultAsync();
            //throw new System.NotImplementedException();
        }
    }
}
