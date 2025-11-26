using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;

namespace Seguimientos.Controllers
{
    public class MemoryController : Controller
    {
        private static List<MemoryCard> cards = new()
        {
            new MemoryCard { Id = 1, ImageUrl = "img1.png", IsFlipped = false },
            new MemoryCard { Id = 2, ImageUrl = "img2.png", IsFlipped = false }
        };

        public IActionResult Index()
        {
            return View(cards);
        }
    }
}

