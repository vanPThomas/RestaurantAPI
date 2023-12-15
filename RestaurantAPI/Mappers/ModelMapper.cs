using BusinessLayer.Model;
using DataLayer.DataLayerModel;
using RestaurantAPI.DTOIn;
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
            return new Location(
                locationDto.Postcode,
                locationDto.City,
                locationDto.Street,
                locationDto.HouseNumberLabel
            );
        }

        public static Contact MapToBusinessModel(ContactDTO contactDto)
        {
            return new Contact(contactDto.Phone, contactDto.Email);
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
                User = new User() { UserID = reservationDto.UserId },
                Restaurant = new Restaurant() { RestaurantID = reservationDto.RestaurantId },
                ReservationNumber = reservationDto.ReservationId,
                Date = reservationDto.Date,
                Time = reservationDto.Time,
                TableNumber = reservationDto.TableNumber,
                NumberOfSeats = reservationDto.NumberOfSeats
            };
        }

        public static Restaurant MapToBusinessModel(RestaurantDTOIn restaurantDto)
        {
            return new Restaurant
            {
                Name = restaurantDto.Name,
                Location = MapToBusinessModel(restaurantDto.Location),
                Cuisine = restaurantDto.Cuisine,
                Contact = MapToBusinessModel(restaurantDto.Contact)
            };
        }
    }
}
