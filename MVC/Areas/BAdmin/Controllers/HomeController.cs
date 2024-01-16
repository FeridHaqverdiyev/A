using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.BAdmin.Controllers
{
    [Area("BAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
