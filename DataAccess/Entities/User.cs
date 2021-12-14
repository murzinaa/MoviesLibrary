using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace MoviesLibrary.DataAccess.Entities
{
    public class User: IdentityUser
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }
        public string FullName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

