using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Context;
using DataLayer.DataLayerModel;
using DataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace DataLayer.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly DBContext _dbContext; // Replace YourDbContext with the actual DbContext used in your application

        //dummy data init start
        public int ReservationId { get; set; }
        public UserEF User { get; set; }
        public RestaurantEF Restaurant { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
        List<ReservationEF> Reservations { get; set; } = new List<ReservationEF>();

        public static List<ReservationEF> GenerateDummyReservations()
        {
            var reservations = new List<ReservationEF>();

            // Dummy data for users, restaurants, and other related entities

            var user1 = new UserEF
            {
                UserId = 1,
                Name = "User1",
                Email = "user1@example.com",
                Phone = "123456789",
                Location = new LocationEF
                {
                    Postcode = "5678",
                    City = "City B",
                    Street = "Main St",
                    HouseNumberLabel = "123"
                },
            };
            var user2 = new UserEF
            {
                UserId = 2,
                Name = "User2",
                Email = "user2@example.com",
                Phone = "987654321",
                Location = new LocationEF
                {
                    Postcode = "1234",
                    City = "City A",
                    Street = "Main St",
                    HouseNumberLabel = "123"
                }
            };

            var restaurant1 = new RestaurantEF
            {
                RestaurantId = 1,
                Name = "Restaurant A",
                Location = new LocationEF
                {
                    Postcode = "1234",
                    City = "City A",
                    Street = "Main St",
                    HouseNumberLabel = "123"
                },
                Cuisine = "Italian",
                Contact = new ContactEF
                {
                    ContactId = 1,
                    Phone = "1234567890",
                    Email = "contact1@example.com"
                }
            };
            var restaurant2 = new RestaurantEF
            {
                RestaurantId = 2,
                Name = "Restaurant B",
                Location = new LocationEF
                {
                    Postcode = "5678",
                    City = "City B",
                    Street = "Main St",
                    HouseNumberLabel = "123"
                },
                Cuisine = "Turkish",
                Contact = new ContactEF
                {
                    ContactId = 2,
                    Phone = "9876543210",
                    Email = "contact2@example.com"
                }
            };
            // Create dummy reservations
            var reservation1 = new ReservationEF
            {
                ReservationId = 1,
                User = user1,
                Restaurant = restaurant1,
                ReservationNumber = 101,
                Date = DateTime.Now.AddDays(1),
                Time = new TimeSpan(19, 0, 0),
                TableNumber = 1,
                NumberOfSeats = 4
            };

            var reservation2 = new ReservationEF
            {
                ReservationId = 2,
                User = user2,
                Restaurant = restaurant2,
                ReservationNumber = 102,
                Date = DateTime.Now.AddDays(2),
                Time = new TimeSpan(20, 0, 0),
                TableNumber = 2,
                NumberOfSeats = 2
            };

            // Add reservations to the list
            reservations.Add(reservation1);
            reservations.Add(reservation2);

            return reservations;
        }

        // dummy data init end

        public ReservationRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            Reservations = GenerateDummyReservations();
        }

        public Reservation GetById(int id)
        {
            Reservation reservationx = new Reservation();

            foreach (ReservationEF reservation in Reservations)
            {
                if (reservation.ReservationId == id)
                {
                    reservationx = ReverseModelMapper.MapToBusinessModel(reservation);
                    break;
                }
            }

            return reservationx;

            //var reservationEF = _dbContext.Reservations.Find(id);
            //return ReverseModelMapper.MapToBusinessModel(reservationEF);
        }

        public void Add(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Reservations.Add(reservationEF);
            _dbContext.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(entity);
            _dbContext.Reservations.Update(reservationEF);
            _dbContext.SaveChanges();
        }

        public void Remove(Reservation entity)
        {
            var reservationEF = ModelMapper.MapToEFModel(entity);
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
