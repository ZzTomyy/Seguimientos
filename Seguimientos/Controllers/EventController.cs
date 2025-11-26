using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Seguimientos.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> events = new();

        public IActionResult Index()
        {
            return View(events);
        }

        [HttpPost]
        public IActionResult Create(string title, string date, string description)
        {
            events.Add(new EventModel
            {
                Id = events.Count + 1,
                Title = title,
                Date = System.DateTime.Parse(date),
                Description = description
            });

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);
            return View(ev);
        }

        [HttpPost]
        public IActionResult Edit(EventModel model)
        {
            var ev = events.FirstOrDefault(e => e.Id == model.Id);
            if (ev != null)
            {
                ev.Title = model.Title;
                ev.Date = model.Date;
                ev.Description = model.Description;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
                events.Remove(ev);

            return RedirectToAction("Index");
        }
    }
}
