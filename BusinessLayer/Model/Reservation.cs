using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }

        public void Update(DateTime date, TimeSpan time, int numberOfSeats) { }

        public void Cancel() { }
    }
}
