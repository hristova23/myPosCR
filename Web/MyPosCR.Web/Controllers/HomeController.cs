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
        private readonly RoleManager<IdentityRole> _identityRole;

        public HomeController(RoleManager<IdentityRole> _identityRole, UserManager<ApplicationUser> _userManager, ILogger<HomeController> logger)
        {
            this._identityRole = _identityRole;
            this._userManager = _userManager;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        //[Authorize ]
        //public async Task<ActionResult> AddAdministratorRoleTest()
        //{
        //    var result = await this._identityRole.CreateAsync(new IdentityRole
        //    {
        //        Name = "Administrator"
        //    });

        //    var user = await this._userManager.GetUserAsync(this.User);
        //    await this._userManager.AddToRoleAsync(user, "Administrator");

        //    return this.Json(result);
        //}

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