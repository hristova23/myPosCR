using Microsoft.AspNetCore.Mvc;

namespace MyPosCR.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
