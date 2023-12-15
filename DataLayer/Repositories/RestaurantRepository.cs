using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly DBContext _dbContext;
        private IRepository<User> _userRepository;

        public RestaurantRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Restaurant GetById(int id)
        {
            var restaurantEF = _dbContext.Restaurants
                .Include(u => u.Location)
                .Include(c => c.Contact)
                .AsNoTracking()
                .FirstOrDefault(u => u.RestaurantId == id);

            return ReverseModelMapper.MapToBusinessModel(restaurantEF);
        }

        public void Add(Restaurant entity)
        {
            var restaurantEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Restaurants.Add(restaurantEF);
            SaveAndClear();
        }

        public void Update(Restaurant entity)
        {
            var existingRestaurantEF = _dbContext.Restaurants
                .Include(u => u.Location)
                .Include(c => c.Contact)
                .FirstOrDefault(u => u.RestaurantId == entity.RestaurantID);

            List<ReservationEF> reservationEFs = new List<ReservationEF>();

            if (existingRestaurantEF != null)
            {
                existingRestaurantEF.Name = entity.Name;
                existingRestaurantEF.Reservations = reservationEFs;
                existingRestaurantEF.Contact.Phone = entity.Contact.Phone;
                existingRestaurantEF.Contact.Email = entity.Contact.Email;
                existingRestaurantEF.Cuisine = entity.Cuisine;
                existingRestaurantEF.Location.Postcode = entity.Location.Postcode;
                existingRestaurantEF.Location.HouseNumberLabel = entity.Location.HouseNumberLabel;
                existingRestaurantEF.Location.Street = entity.Location.Street;
                existingRestaurantEF.Location.City = entity.Location.City;

                _dbContext.Restaurants.Update(existingRestaurantEF);
                SaveAndClear();
            }
            else
            {
                Console.WriteLine($"User with ID {entity.RestaurantID} not found for update.");
            }
        }

        public void Remove(Restaurant entity)
        {
            var restaurantEF = ModelMapper.MapToEFModel(entity, entity.RestaurantID);
            _dbContext.Restaurants.Remove(restaurantEF);
            SaveAndClear();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }

        private void SaveAndClear()
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }
}
