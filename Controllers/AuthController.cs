using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Models.AuthVM;

namespace MvcMovie.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> SignUp(SignUp signUp)
        //{
        //    var email= await _userManager.FindByEmailAsync(signUp.Email);
        //    if (email == null)
        //    {
        //        IdentityUser user = new IdentityUser
        //        {
        //            UserName = signUp.Name,
        //            Email = signUp.Email,
        //            PhoneNumber = signUp.PhoneNumber,
        //            PasswordHash = signUp.Password,
        //        };
        //    var users= await _userManager.CreateAsync(user);
        //    return View();
        //    }
        //    return View();        
        //}
    }
}
