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
                    Restaurant = new Restaurant() { RestaurantID = id },
                    NumberOfSeats = 3,
                    ReservationID = 3,
                    TableNumber = 2,
                    User = new User() { UserID = 1 }
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

        public List<string> GetFreeTablesByRestaurant(int id)
        {
            // Create instance 1
            Restaurant restaurant1 = new Restaurant
            {
                RestaurantID = 1,
                Name = "Restaurant One",
                Location = new Location("1234", "City1"),
                Cuisine = "Cuisine1",
                Contact = new Contact("123-456-7890", "restaurant1@example.com")
            };

            // Fill tables for instance 1
            FillTables(restaurant1);

            // Create instance 2
            Restaurant restaurant2 = new Restaurant
            {
                RestaurantID = 2,
                Name = "Restaurant Two",
                Location = new Location("5432", "City2"),
                Cuisine = "Cuisine2",
                Contact = new Contact("987-654-3210", "restaurant2@example.com")
            };

            // Fill tables for instance 2
            FillTables(restaurant2);
            List<string> tables = new List<string>();

            if (id == 1)
            {
                foreach (var table in restaurant1.TablesToFree)
                    if (table.Value)
                        tables.Add(table.Key);
            }
            else if (id == 2)
            {
                foreach (var table in restaurant2.TablesToFree)
                    if (table.Value)
                        tables.Add(table.Key);
            }

            return tables;
        }

        void FillTables(Restaurant restaurant)
        {
            // Generate at least ten tables with random boolean values
            Random random = new Random();
            for (int i = 1; i <= 20; i++)
            {
                string tableName = $"Table{i}";
                bool isFree = random.Next(2) == 0; // Randomly set true or false
                restaurant.TablesToFree.Add(tableName, isFree);
            }
        }
    }
}
