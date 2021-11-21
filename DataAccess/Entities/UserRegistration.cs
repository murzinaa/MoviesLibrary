using Microsoft.AspNetCore.Identity;

namespace MoviesLibrary.DataAccess.Entities
{
    public class UserRegistration : IdentityUser
    {
        public string FullName { get; set; }
    }
}
