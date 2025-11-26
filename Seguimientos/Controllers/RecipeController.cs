using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;

namespace Seguimientos.Controllers
{
    public class RecipeController : Controller
    {
        private static List<Recipe> recipes = new();

        public IActionResult Index()
        {
            return View(recipes);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            recipe.Id = recipes.Count + 1;
            recipes.Add(recipe);

            return RedirectToAction("Index");
        }
    }
}
