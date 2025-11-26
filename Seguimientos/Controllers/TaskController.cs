using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Seguimientos.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            tasks.Add(new TaskItem
            {
                Id = tasks.Count + 1,
                Title = title,
                IsCompleted = false
            });

            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }

            return RedirectToAction("Index");
        }
    }
}
