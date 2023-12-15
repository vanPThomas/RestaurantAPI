using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantService(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            Restaurant restaurant = _restaurantRepository.GetById(restaurantId);
            return restaurant;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(restaurant.Name))
                    _restaurantRepository.Add(restaurant);
                else
                    throw new RestaurantException("Restaurant name can not be empty");
            }
            catch (Exception ex)
            {
                throw new RestaurantException("Restaurant name can not be empty");
            }
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(restaurant.Name))
                    _restaurantRepository.Update(restaurant);
                else
                    throw new RestaurantException("Restaurant name can not be empty");
            }
            catch (Exception ex)
            {
                throw new RestaurantException("Restaurant name can not be empty");
            }
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Remove(restaurant);
        }

        public List<Reservation> GetReservationsByRestaurant(int id)
        {
            //List<Reservation> reservations = _restaurantRepository.GetById(id).Reservations;
            List<Reservation> reservations = new List<Reservation>();
            if (id == 1)
            {
                Reservation reservation1 = new Reservation
                {
                    Restaurant = new Restaurant() { RestaurantID = id},
                    NumberOfSeats = 3,
                    ReservationID = 3,
                    TableNumber = 2,
                    User = new User() { UserID = 1}
                };
                Reservation reservation2 = new Reservation
                {
                    Restaurant = new Restaurant() { RestaurantID = id },
                    NumberOfSeats = 4,
                    ReservationID = 4,
                    TableNumber = 2,
                    User = new User() { UserID = 1 }
                };
                reservations.Add(reservation1);
                reservations.Add(reservation2);
            }
            else if (id == 2)
            {
                Reservation reservation1 = new Reservation
                {
                    Restaurant = new Restaurant() { RestaurantID = id },
                    NumberOfSeats = 3,
                    ReservationID = 1,
                    TableNumber = 2,
                    User = new User() { UserID = 1 }
                };
                Reservation reservation2 = new Reservation
                {
                    Restaurant = new Restaurant() { RestaurantID = id },
                    NumberOfSeats = 4,
                    ReservationID = 2,
                    TableNumber = 2,
                    User = new User() { UserID = 1 }
                };
                reservations.Add(reservation1);
                reservations.Add(reservation2);
            }

            return reservations;
        }
    }
}
