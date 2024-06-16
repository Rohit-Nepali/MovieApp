using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcMovie.Models.AuthVM;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MvcMovie.Controllers
{
    public class AuthsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            var email = await _userManager.FindByEmailAsync(signUp.Email);
            if (email == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = signUp.Name,
                    Email = signUp.Email,
                    PhoneNumber = signUp.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, signUp.Password);
                return RedirectToAction("SignIn");
            }
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn signIn)
        {
           var user = await _signInManager.PasswordSignInAsync(signIn.Username,signIn.Password,false,false);
           if (user.Succeeded) {
                var users = await _userManager.FindByEmailAsync(signIn.Email);
                var token =   CreateToken(users);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public  string CreateToken(IdentityUser users)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, users.UserName),
                new Claim(ClaimTypes.Email, users.Email)
             };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("lkdjsaf;ldskjfladskjfladsfjasdsdfaslfdslfhads;fkdsj;fkladsfasdfadsf"));
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}

