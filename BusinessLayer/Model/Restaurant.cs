using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Cuisine { get; set; }
        public Contact Contact { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Reservation> GetReservations(DateTime date)
        {
            List<Reservation> reservations = new List<Reservation>();
            return reservations;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            return reservations;
        }
    }
}
