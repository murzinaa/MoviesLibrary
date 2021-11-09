//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//namespace DataAccess.Entities
//{
//    public class FavouriteMovie
//    {
//        public int MovieId{ get; set; }
//        public List<User> Users{ get; set; }
//        //public int UserId { get; set; }

//    }
//}
using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public class FavouriteMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public string Title { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
