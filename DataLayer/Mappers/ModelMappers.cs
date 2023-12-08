using BusinessLayer.Model;
using DataLayer.DataLayerModel;

namespace DataLayer.Mappers
{
    public static class ModelMapper
    {
        public static ContactEF MapToEFModel(Contact contact)
        {
            return new ContactEF { Phone = contact.Phone, Email = contact.Email, };
        }

        public static LocationEF MapToEFModel(Location location)
        {
            return new LocationEF
            {
                Postcode = location.Postcode,
                City = location.City,
                Street = location.Street,
                HouseNumberLabel = location.HouseNumberLabel,
            };
        }

        public static ReservationEF MapToEFModel(Reservation reservation)
        {
            return new ReservationEF
            {
                ReservationId = reservation.ReservationID,
                User = MapToEFModel(reservation.User),
                Restaurant = MapToEFModel(reservation.Restaurant),
                ReservationNumber = reservation.ReservationNumber,
                Date = reservation.Date,
                Time = reservation.Time,
                TableNumber = reservation.TableNumber,
                NumberOfSeats = reservation.NumberOfSeats
            };
        }

        public static UserEF MapToEFModel(User user)
        {
            return new UserEF
            {
                UserId = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Location = MapToEFModel(user.Location),
            };
        }

        public static RestaurantEF MapToEFModel(Restaurant restaurant)
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
