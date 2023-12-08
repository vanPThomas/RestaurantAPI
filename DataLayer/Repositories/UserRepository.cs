using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            var userEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Users.Update(userEF);
            SaveAndClear();
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
