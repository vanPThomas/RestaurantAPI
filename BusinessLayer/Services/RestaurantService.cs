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
    }
}
