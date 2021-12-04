using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MoviesLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLibrary.Web.Helpers
{
    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User.Identity.Name;
            return user;
        }
    }
}


