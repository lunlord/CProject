using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CProject.Models;
using CProject.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace CProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<User> userManager,
            SignInManager<User> signInManager, UserContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {         
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        

        [HttpPost]    
        public async Task<IActionResult> Create(CreateUserModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Adress = model.Adress};

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)   
            {               
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, model.Role));
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
            
        //    User user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    EditUserModel model = new EditUserModel { Email = user.Email, PhoneNumber = user.PhoneNumber };
        //    return View(model);
        //} 


        //[HttpPost]
        //public async Task<IActionResult> Edit(EditUserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _userManager.FindByIdAsync(model.Id);
        //        if (user != null)
        //        {
        //            user.Email = model.Email;
        //            user.UserName = model.Email;
        //            user.PhoneNumber = model.PhoneNumber;

        //            var result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            ModelState.AddModelError("", "Указаны не корректные данные");
        //        }
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Delete(string id)
        //{
        //    return View();
        //}
            
        //[HttpPost]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    User user = await _userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        IdentityResult result = await _userManager.DeleteAsync(user);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
