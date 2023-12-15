using BusinessLayer.Model;
using DataLayer.DataLayerModel;
using System.ComponentModel.Design;

namespace DataLayer.Mappers
{
    public static class ReverseModelMapper
    {
        public static Contact MapToBusinessModel(ContactEF contactEF)
        {
            if (contactEF != null)
            {
                return new Contact(contactEF.Phone, contactEF.Email);
            }
            else
            {
                return null;
            }
        }

        public static Location MapToBusinessModel(LocationEF locationEF)
        {
            if (locationEF != null)
            {
                return new Location(
                    locationEF.Postcode,
                    locationEF.City,
                    locationEF.Street,
                    locationEF.HouseNumberLabel
                );
            }
            else
            {
                return null;
            }
        }

        public static Reservation MapToBusinessModel(ReservationEF reservationEF)
        {
            if (reservationEF != null)
            {
                return new Reservation
                {
                    ReservationID = reservationEF.ReservationId,
                    User = MapToBusinessModel(reservationEF.User),
                    Restaurant = MapToBusinessModel(reservationEF.Restaurant),
                    ReservationNumber = reservationEF.ReservationNumber,
                    Date = reservationEF.Date,
                    Time = reservationEF.Time,
                    TableNumber = reservationEF.TableNumber,
                    NumberOfSeats = reservationEF.NumberOfSeats
                };
            }
            else
            {
                return null;
            }
        }

        public static User MapToBusinessModel(UserEF userEF)
        {
            if (userEF != null)
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
            else
            {
                return null;
            }
        }

        public static Restaurant MapToBusinessModel(RestaurantEF restaurantEF)
        {
            if (restaurantEF != null)
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
            else
            {
                return null;
            }
        }
    }
}
