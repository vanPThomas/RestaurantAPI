using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Administrator
    {
        public List<Reservation> GetRestaurantReservations(int restaurantID, DateTime date)
        {
            List<Reservation> reservations = new List<Reservation>();
            return reservations;
        }

        public List<Reservation> GetAllRestaurantReservations(int restaurantID)
        {
            List<Reservation> reservations = new List<Reservation>();
            return reservations;
        }
    }
}
