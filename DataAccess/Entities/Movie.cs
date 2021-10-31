using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        //public int GenreID { get; set; }
        public string Title { get; set; }
        public double AverageVote { get; set; }
        public int CountOfVotes { get; set; }
        public string Language { get; set; }
        public double Popularity { get; set; }
        public string Overview { get; set; }
    }
}
