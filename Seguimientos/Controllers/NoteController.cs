using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;

namespace Seguimientos.Controllers
{
    public class NoteController : Controller
    {
        private static List<Note> notes = new();

        public IActionResult Index()
        {
            return View(notes);
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            note.Id = notes.Count + 1;
            note.CreatedAt = DateTime.Now;
            notes.Add(note);

            return RedirectToAction("Index");
        }
    }
}
