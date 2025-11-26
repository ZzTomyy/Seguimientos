using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;

namespace Seguimientos.Controllers
{
    public class ExpenseController : Controller
    {
        private static List<Expense> expenses = new();

        public IActionResult Index()
        {
            return View(expenses);
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            expense.Id = expenses.Count + 1;
            expense.Date = DateTime.Now;
            expenses.Add(expense);

            return RedirectToAction("Index");
        }
    }
}
