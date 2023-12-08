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
            // Additional business logic or validation can be added here
            _restaurantRepository.Add(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            // Additional business logic or validation can be added here
            _restaurantRepository.Update(restaurant);
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            // Additional business logic or validation can be added here
            _restaurantRepository.Remove(restaurant);
        }
    }
}
