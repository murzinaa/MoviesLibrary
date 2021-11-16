//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//namespace DataAccess.Entities
//{
//    public class User
//    {
//        [Key]
//        public int Id{ get; set; }
//        public int UserRegistrationId { get; set; }
//        public List<FavouriteMovie> FavourtiteMovies { get; set; }
//        public List<Comment> Comments { get; set; }
//        //public ICollection<FavouriteMovie> FavourtiteMovies { get; set; }
//        //public ICollection<Comment> Comments { get; set; }
//    }
//}

using System.Collections.Generic;


namespace DataAccess.Entities
{
    public class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

