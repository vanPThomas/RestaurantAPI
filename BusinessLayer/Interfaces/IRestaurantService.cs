using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IRestaurantService
    {
        Restaurant GetRestaurantById(int restaurantId);
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void RemoveRestaurant(Restaurant restaurant);
        public List<Reservation> GetReservationsByRestaurant(int id);
        List<string> GetFreeTablesByRestaurant(int id);
    }
}
