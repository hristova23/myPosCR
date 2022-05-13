using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPosCR.Data;
using MyPosCR.Web.Models;
using MyPosCR.Web.Models.Users;
using System.Diagnostics;

namespace MyPosCR.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var users = this.db.Users.Select(u => new IndexUserViewModel
            {
                Username= u.UserName,
                PhoneNumber= u.PhoneNumber,
                Credits = u.Credits
            }).ToList();
            viewModel.Users = users;

            return View(viewModel);
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