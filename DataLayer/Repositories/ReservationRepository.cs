using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace DataLayer.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly DBContext _dbContext; // Replace YourDbContext with the actual DbContext used in your application
        private IRepository<Restaurant> _restaurantRepository;
        private IRepository<User> _userRepository;

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

        public void Add(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(
                entity,
                _restaurantRepository,
                _userRepository
            );
            _dbContext.Reservations.Add(reservationEF);
            _dbContext.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(
                entity,
                _restaurantRepository,
                _userRepository
            );
            _dbContext.Reservations.Update(reservationEF);
            _dbContext.SaveChanges();
        }

        public void Remove(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(
                entity,
                _restaurantRepository,
                _userRepository
            );
            _dbContext.Reservations.Remove(reservationEF);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _dbContext.Reservations.Select(ReverseModelMapper.MapToBusinessModel).ToList();
        }

        public List<Reservation> GetReservationsByUser(int userId)
        {
            return _dbContext.Reservations
                .Where(r => r.User.UserId == userId)
                .Select(ReverseModelMapper.MapToBusinessModel)
                .ToList();
        }

        public List<Reservation> GetReservationsByRestaurant(int restaurantId, DateTime date)
        {
            //return _dbContext.Reservations
            //    .Where(r => r.Restaurant.RestaurantId == restaurantId && r.Date == date)
            //    .Select(ModelMapper.MapToEFModel)
            //    .ToList();

            return new List<Reservation>();
        }
    }
}
