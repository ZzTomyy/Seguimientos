using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Seguimientos.Controllers
{
    public class ReservationController : Controller
    {
        private static List<Reservation> reservations = new();

        public IActionResult Index()
        {
            return View(reservations);
        }

        [HttpPost]
        public IActionResult Create(string clientName, string service, string date, string time)
        {
            var reservationDate = System.DateTime.Parse(date);

            // ✅ Check availability
            bool isAvailable = !reservations.Any(r =>
                r.Date.Date == reservationDate.Date &&
                r.Time == time
            );

            if (!isAvailable)
            {
                ViewBag.Error = "This time slot is already reserved.";
                return View("Index", reservations);
            }

            reservations.Add(new Reservation
            {
                Id = reservations.Count + 1,
                ClientName = clientName,
                Service = service,
                Date = reservationDate,
                Time = time
            });

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
                reservations.Remove(reservation);

            return RedirectToAction("Index");
        }
    }
}

