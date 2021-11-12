using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _user;

        public AccountController(IUserService user)
        {
            _user = user;
        }

        public IActionResult Login()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_user.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!(await _user.CheckForEnableAsync(user.Login, user.Password)))
                return View(user);
            user = await _user.GetUserByLoginAndPasswordAsync(user.Login, user.Password);
            await Authenticate(user);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (await _user.CheckForEnableAsync(user.Login, user.Password))
                return View(user);
            user = await _user.AddUserAsync(user);
            await Authenticate(user);

            return RedirectToAction("Login", "Account");
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name!),
                new Claim("Login",user.Name.ToString()),
                new Claim("Role",user.Role?.Name!)
            };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
