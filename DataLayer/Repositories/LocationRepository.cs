using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly DBContext _dbContext; // Replace YourDbContext with the actual DbContext used in your application

        public LocationRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Location GetById(int id)
        {
            var locationEF = _dbContext.Locations.Find(id);
            return ReverseModelMapper.MapToBusinessModel(locationEF);
        }

        public void Add(Location entity)
        {
            var locationEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Locations.Add(locationEF);
            _dbContext.SaveChanges();
        }

        public void Update(Location entity)
        {
            var locationEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Locations.Update(locationEF);
            _dbContext.SaveChanges();
        }

        public void Remove(Location entity)
        {
            var locationEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Locations.Remove(locationEF);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Location> GetAll()
        {
            return _dbContext.Locations.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }
    }
}
