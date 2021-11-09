using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesLibrary.Controllers
{
    public class MovieResultController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(string comment)
        {
            ClaimsPrincipal currentUser = User;
            var userEmail = currentUser.FindFirst(ClaimTypes.Email).Value;
            Comment comment1 = new Comment { Body = comment };
            return View();
        }
    }
}
