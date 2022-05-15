using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPosCR.Data.Models;
using MyPosCR.Web.Models;
using System.Diagnostics;

namespace MyPosCR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<ApplicationUser> _userManager, ILogger<HomeController> logger)
        {
            this._userManager = _userManager;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}