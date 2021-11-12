using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext context;
        public MovieService(MovieContext context)
        {
            this.context = context;

        }
        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
    }
}
