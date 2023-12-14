using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly DBContext _dbContext;
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<User> _userRepository;

        public ReservationRepository(
            DBContext dbContext,
            IRepository<Restaurant> rr,
            IRepository<User> ru
        )
        {
            _dbContext = dbContext;
            _restaurantRepository = rr;
            _userRepository = ru;
        }

        public Reservation GetById(int id)
        {
            try
            {
                var reservationEF = _dbContext.Reservations
                    .Include(r => r.User)
                    .ThenInclude(l => l.Location)
                    .Include(r => r.Restaurant)
                    .ThenInclude(l => l.Location)
                    .Include(r => r.Restaurant)
                    .ThenInclude(c => c.Contact)
                    .FirstOrDefault(r => r.ReservationId == id);

                return ReverseModelMapper.MapToBusinessModel(reservationEF);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Add(Reservation entity)
        {
            try
            {
                var reservationEF = ModelMapper.MapToEFModel(
                    entity,
                    _restaurantRepository,
                    _userRepository
                );
                _dbContext.Reservations.Add(reservationEF);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Reservation entity)
        {
            try
            {
                var reservationEF = ModelMapper.MapToEFModel(
                    entity,
                    _restaurantRepository,
                    _userRepository
                );
                _dbContext.Reservations.Update(reservationEF);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Remove(Reservation entity)
        {
            try
            {
                var reservationEF = ModelMapper.MapToEFModel(
                    entity,
                    _restaurantRepository,
                    _userRepository
                );
                _dbContext.Reservations.Remove(reservationEF);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            try
            {
                return _dbContext.Reservations
                    .Select(ReverseModelMapper.MapToBusinessModel)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Reservation> GetReservationsByUser(int userId)
        {
            try
            {
                return _dbContext.Reservations
                    .Where(r => r.User.UserId == userId)
                    .Select(ReverseModelMapper.MapToBusinessModel)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
