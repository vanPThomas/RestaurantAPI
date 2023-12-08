using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DBContext _dbContext; // Replace YourDbContext with the actual DbContext used in your application

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(int id)
        {
            var userEF = _dbContext.Users.Find(id);
            return ReverseModelMapper.MapToBusinessModel(userEF);
        }

        public void Add(User entity)
        {
            var userEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Users.Add(userEF);
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            var userEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Users.Update(userEF);
            _dbContext.SaveChanges();
        }

        public void Remove(User entity)
        {
            var userEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Users.Remove(userEF);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }

        // You can add additional methods specific to User if needed
    }
}
