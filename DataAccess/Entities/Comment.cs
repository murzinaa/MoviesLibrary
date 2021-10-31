using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MoiveId { get; set; }
        public string Body { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
