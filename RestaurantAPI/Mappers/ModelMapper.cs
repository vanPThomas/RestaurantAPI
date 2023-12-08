using BusinessLayer.Model;
using RestaurantAPI.DTOs;

namespace RestaurantAPI.Mappers
{
    public static class ModelMapper
    {
        public static User MapToBusinessModel(UserDTO userDto)
        {
            return new User
            {
                UserID = userDto.UserId,
                Name = userDto.Name,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Location = MapToBusinessModel(userDto.Location)
            };
        }

        public static Location MapToBusinessModel(LocationDTO locationDto)
        {
            return new Location
            {
                Postcode = locationDto.Postcode,
                City = locationDto.City,
                Street = locationDto.Street,
                HouseNumberLabel = locationDto.HouseNumberLabel
            };
        }

        public static Contact MapToBusinessModel(ContactDTO contactDto)
        {
            return new Contact { Phone = contactDto.Phone, Email = contactDto.Email };
        }

        public static Restaurant MapToBusinessModel(RestaurantDTO restaurantDto)
        {
            return new Restaurant
            {
                RestaurantID = restaurantDto.RestaurantId,
                Name = restaurantDto.Name,
                Location = MapToBusinessModel(restaurantDto.Location),
                Cuisine = restaurantDto.Cuisine,
                Contact = MapToBusinessModel(restaurantDto.Contact)
            };
        }

        public static Reservation MapToBusinessModel(ReservationDTO reservationDto)
        {
            return new Reservation
            {
                ReservationID = reservationDto.ReservationId,
                User = MapToBusinessModel(reservationDto.User),
                Restaurant = MapToBusinessModel(reservationDto.Restaurant),
                ReservationNumber = reservationDto.ReservationNumber,
                Date = reservationDto.Date,
                Time = reservationDto.Time,
                TableNumber = reservationDto.TableNumber,
                NumberOfSeats = reservationDto.NumberOfSeats
            };
        }
    }
}
