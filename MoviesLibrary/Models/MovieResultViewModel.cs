using DataAccess.Entities;
using MoviesLibrary.Models;
using System.Collections.Generic;

namespace MoviesLibrary.ViewModels
{
    public class MovieResultViewModel
    {
        public FullMovieResult ResultById{ get; set; }
        public List<Comment> MovieComments { get; set; }
    }
}
