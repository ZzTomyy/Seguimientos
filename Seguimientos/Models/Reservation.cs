using System;

namespace Seguimientos.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Service { get; set; }
    }
}
