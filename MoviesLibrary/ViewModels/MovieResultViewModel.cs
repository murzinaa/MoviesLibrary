using APIProviders.MovResultById;
using DataAccess.Entities;
using System.Collections.Generic;

namespace MoviesLibrary.ViewModels
{
    public class MovieResultViewModel
    {
        public MovieResultById ResultById{ get; set; }
        public List<Comment> MovieComments { get; set; }
    }
}
