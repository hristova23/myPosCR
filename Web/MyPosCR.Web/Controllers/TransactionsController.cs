using Microsoft.AspNetCore.Mvc;

namespace MyPosCR.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
