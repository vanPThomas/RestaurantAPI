using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(int id)
        {
            var userEF = _dbContext.Users
                .Include(u => u.Location)
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == id);

            return ReverseModelMapper.MapToBusinessModel(userEF);
        }

        public void Add(User entity)
        {
            var userEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Users.Add(userEF);
            SaveAndClear();
        }

        public void Update(User entity)
        {
            var existingUserEF = _dbContext.Users
                .Include(u => u.Location) // Include Location to ensure it's loaded
                .FirstOrDefault(u => u.UserId == entity.UserID);
            if (existingUserEF != null)
            {
                var userEF = ModelMapper.MapToEFModel(entity);
                existingUserEF.Name = entity.Name;
                existingUserEF.Email = entity.Email;
                existingUserEF.Phone = entity.Phone;
                existingUserEF.Location.Postcode = entity.Location.Postcode;
                existingUserEF.Location.HouseNumberLabel = entity.Location.HouseNumberLabel;
                existingUserEF.Location.Street = entity.Location.Street;
                existingUserEF.Location.City = entity.Location.City;

                _dbContext.Users.Update(existingUserEF);
                SaveAndClear();
            }
            else
            {
                Console.WriteLine($"User with ID {entity.UserID} not found for update.");
            }
        }

        public void Remove(User entity)
        {
            var userEF = ModelMapper.MapToEFModel(entity, entity.UserID);
            _dbContext.Users.Remove(userEF);
            SaveAndClear();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }

        private void SaveAndClear()
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }
}
