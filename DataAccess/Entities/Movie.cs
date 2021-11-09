//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//namespace DataAccess.Entities
//{

//    public class Movie
//    {
//        [Key]
//        public int Id { get; set; }
//        public string Title { get; set; }
//        //public int MovieId { get; set; }
//        //public int GenreID { get; set; }
//        //public string Title { get; set; }
//        //public double AverageVote { get; set; }
//        //public int CountOfVotes { get; set; }
//        //public string Language { get; set; }
//        // public double Popularity { get; set; }
//        //public string Overview { get; set; }
//    }
//}
using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
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
