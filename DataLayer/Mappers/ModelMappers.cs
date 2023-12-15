using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.DataLayerModel;
using DataLayer.Repositories;

namespace DataLayer.Mappers
{
    public static class ModelMapper
    {
        public static ContactEF MapToEFModel(Contact contact)
        {
            try { }
            catch (Exception ex) { }
            return new ContactEF { Phone = contact.Phone, Email = contact.Email, };
        }

        public static LocationEF MapToEFModel(Location location)
        {
            try
            {
                return new LocationEF
                {
                    Postcode = location.Postcode,
                    City = location.City,
                    Street = location.Street,
                    HouseNumberLabel = location.HouseNumberLabel,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ReservationEF MapToEFModel(
            Reservation reservation,
            IRepository<Restaurant> rr,
            IRepository<User> ru
        )
        {
            return new ReservationEF
            {
                User = MapToEFModel(reservation.User),
                Restaurant = MapToEFModel(reservation.Restaurant),
                Date = reservation.Date,
                Time = reservation.Time,
                TableNumber = reservation.TableNumber,
                NumberOfSeats = reservation.NumberOfSeats
            };
        }

        public static UserEF MapToEFModel(User user)
        {
            return new UserEF(user.Name, user.Email, user.Phone, MapToEFModel(user.Location));
        }

        public static UserEF MapToEFModel(User user, int id)
        {
            return new UserEF(
                user.UserID,
                user.Name,
                user.Email,
                user.Phone,
                MapToEFModel(user.Location)
            );
        }

        public static RestaurantEF MapToEFModel(Restaurant restaurant)
        {
            return new RestaurantEF
            {
                Name = restaurant.Name,
                Location = MapToEFModel(restaurant.Location),
                Cuisine = restaurant.Cuisine,
                Contact = MapToEFModel(restaurant.Contact),
            };
        }

        public static RestaurantEF MapToEFModel(Restaurant restaurant, int id)
        {
            return new RestaurantEF
            {
                RestaurantId = restaurant.RestaurantID,
                Name = restaurant.Name,
                Location = MapToEFModel(restaurant.Location),
                Cuisine = restaurant.Cuisine,
                Contact = MapToEFModel(restaurant.Contact),
            };
        }
    }
}
