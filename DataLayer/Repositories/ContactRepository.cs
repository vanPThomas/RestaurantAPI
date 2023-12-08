using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly DBContext _dbContext; // Replace YourDbContext with the actual DbContext used in your application

        public ContactRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contact GetById(int id)
        {
            var contactEF = _dbContext.Contacts.Find(id);
            return ReverseModelMapper.MapToBusinessModel(contactEF);
        }

        public void Add(Contact entity)
        {
            var contactEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Contacts.Add(contactEF);
            _dbContext.SaveChanges();
        }

        public void Update(Contact entity)
        {
            var contactEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Contacts.Update(contactEF);
            _dbContext.SaveChanges();
        }

        public void Remove(Contact entity)
        {
            var contactEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Contacts.Remove(contactEF);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _dbContext.Contacts.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }
    }
}
