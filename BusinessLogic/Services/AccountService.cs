//using Microsoft.AspNetCore.Identity;
//using MoviesLibrary.BusinessLogic.Interfaces;
//using MoviesLibrary.DataAccess.Entities;
//using MoviesLibrary.DataAccess.Registration;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
////using System.Web.Mvc;

//namespace MoviesLibrary.BusinessLogic.Services
//{
//    public class AccountService : IAccountService
//    {
//        private readonly UserManager<UserRegistration> _userManager;
//        private readonly SignInManager<UserRegistration> _signInManager;

//        public AccountService(UserManager<UserRegistration> userManager, SignInManager<UserRegistration> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }
//        public Task<IEnumerable<IdentityError>> Login(Login model)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<IdentityError>> Register(Registration model)
//        {
//            if (ModelState.IsValid)
//            {
//                UserRegistration user = new UserRegistration { Email = model.Email, UserName = model.Email };

//                var result = await _userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {

//                    await _signInManager.SignInAsync(user, false);
//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError(string.Empty, error.Description);
//                    }
//                }
//            }
//        }
//    }
//}
