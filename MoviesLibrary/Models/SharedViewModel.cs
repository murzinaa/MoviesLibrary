using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.Models;
using System.Collections.Generic;

namespace MoviesLibrary.Web.Models
{
    public class SharedViewModel
    {
        public FullMovieResult ResultById { get; set; }
        public List<Comment> MovieComments { get; set; }
        public bool IsInFavourite { get; set; }
        public bool EditComment { get; set; }
        public int CommentId { get; set; }
    }
}
