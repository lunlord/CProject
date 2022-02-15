using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            return Redirect("~/Account/Welcome");
        }
    }
}