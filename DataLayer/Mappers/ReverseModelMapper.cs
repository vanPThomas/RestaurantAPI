using BusinessLayer.Model;
using DataLayer.DataLayerModel;

namespace DataLayer.Mappers
{
    public static class ReverseModelMapper
    {
        public static Contact MapToBusinessModel(ContactEF contactEF)
        {
            return new Contact(contactEF.Phone, contactEF.Email);
        }

        public static Location MapToBusinessModel(LocationEF locationEF)
        {
            return new Location(
                locationEF.Postcode,
                locationEF.City,
                locationEF.Street,
                locationEF.HouseNumberLabel
            );
        }

        public static Reservation MapToBusinessModel(ReservationEF reservationEF)
        {
            return new Reservation
            {
                ReservationID = reservationEF.ReservationId,
                UserId = reservationEF.User.UserId,
                RestaurantId = reservationEF.Restaurant.RestaurantId,
                ReservationNumber = reservationEF.ReservationNumber,
                Date = reservationEF.Date,
                Time = reservationEF.Time,
                TableNumber = reservationEF.TableNumber,
                NumberOfSeats = reservationEF.NumberOfSeats
            };
        }

        public static User MapToBusinessModel(UserEF userEF)
        {
            return new User
            {
                UserID = userEF.UserId,
                Name = userEF.Name,
                Email = userEF.Email,
                Phone = userEF.Phone,
                Location = MapToBusinessModel(userEF.Location),
            };
        }

        public static Restaurant MapToBusinessModel(RestaurantEF restaurantEF)
        {
            return new Restaurant
            {
                RestaurantID = restaurantEF.RestaurantId,
                Name = restaurantEF.Name,
                Location = MapToBusinessModel(restaurantEF.Location),
                Cuisine = restaurantEF.Cuisine,
                Contact = MapToBusinessModel(restaurantEF.Contact),
            };
        }
    }
}
