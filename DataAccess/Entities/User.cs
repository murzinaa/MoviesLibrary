using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id{ get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public ICollection<FavouriteMovie> FavourtiteMovies { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
