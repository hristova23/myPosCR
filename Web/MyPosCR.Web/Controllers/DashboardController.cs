using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPosCR.Data;
using MyPosCR.Web.Models.Dashboard;

namespace MyPosCR.Web.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;
        public DashboardController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var users = this.db.Users.Select(u => new IndexUserViewModel
            {
                Username = u.UserName,
                PhoneNumber = u.PhoneNumber,
                Credits = u.Credits
            }).ToList();
            viewModel.Users = users;

            return View(viewModel);
        }
    }
}
