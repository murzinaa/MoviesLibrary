using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class UserRegistration : IdentityUser
    {
        public string FullName { get; set; }
    }
}
