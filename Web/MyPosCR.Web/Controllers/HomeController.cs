using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myPosCR.Services;
using MyPosCR.Data;
using MyPosCR.Data.Models;
using MyPosCR.Web.Models;
using MyPosCR.Web.Models.Home;
using System.Diagnostics;

namespace MyPosCR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _identityRole;

        private readonly ITransactionsService transactionsService;
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db, RoleManager<IdentityRole> _identityRole, ITransactionsService transactionsService, UserManager<ApplicationUser> _userManager, ILogger<HomeController> logger)
        {
            this._identityRole = _identityRole;
            this._userManager = _userManager;
            this._logger = logger;
            this.db = db;


            this.transactionsService = transactionsService;
        }

        public IActionResult Index()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            string currentUserId = ViewBag.userId;

            var transactions = this.db.Transactions.Where(t=>t.SenderId == currentUserId || t.RecieverId == currentUserId).Select(t => new IndexTransactionViewModel
            {
                Amount = t.Amount,
                Date = t.Date
            }).ToList();

            var viewModel = new IndexViewModel();
            viewModel.Transactions = transactions;

            return View(viewModel);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}