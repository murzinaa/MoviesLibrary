using System.Collections.Generic;

namespace MoviesLibrary.DataAccess.Entities
{
    public class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
