using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;

namespace Seguimientos.Controllers
{
    public class TipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Tip model)
        {
            model.TipAmount = model.BillAmount * model.Percentage / 100;
            model.TotalAmount = model.BillAmount + model.TipAmount;

            return View("Index", model);
        }
    }
}
