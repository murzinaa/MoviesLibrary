using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities;

namespace MoviesLibrary.Controllers
{
    [Authorize]
    public class FavMoviesController : Controller
    {
        // Stores UserManager
        private readonly UserManager<UserRegistration> _manager;

        // Inject UserManager using dependency injection.
        // Works only if you choose "Individual user accounts" during project creation.
        public FavMoviesController(UserManager<UserRegistration> manager)
        {
            _manager = manager;
        }

        // You can also just take part after return and use it in async methods.
        private async Task<UserRegistration> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }

        // Generic demo method.
        //public async Task DemoMethod()
        //{
        //    var user = await GetCurrentUser();
        //    string userEmail = user.Email; // Here you gets user email 
        //    string userId = user.Id;
        //}
        public IActionResult Favourite()
        {
            return View();

        }
    }
}
