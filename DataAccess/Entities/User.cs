using System.Collections.Generic;


namespace MoviesLibrary.DataAccess.Entities
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

