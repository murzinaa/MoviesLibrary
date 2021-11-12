
using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        //public string MovieTitle { get; set; }
        public string Body { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}

