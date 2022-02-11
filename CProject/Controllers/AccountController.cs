using CProject.Models;
using CProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
                User user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Adress = model.Adress };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user  = await _userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return View(model);
            }

             var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect("~/Account/Welcome");
            } 

                return Redirect("~/Account/Login");
        }

        //private async Task Authenticate(string userEmail)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name,userEmail)
        //    };
        //    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
        //}

        [Authorize]
        public IActionResult Welcome()
        {
            ViewBag.Email = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //[HttpGet]
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
    }
}
