using Microsoft.AspNetCore.Mvc;

namespace Seguimientos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

