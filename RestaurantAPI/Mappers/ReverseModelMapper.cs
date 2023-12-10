using BusinessLayer.Model;
using RestaurantAPI.DTOs;

namespace RestaurantAPI.Mappers
{
    public static class ReverseModelMapper
    {
        public static UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Location = MapToDTO(user.Location)
            };
        }

        public static LocationDTO MapToDTO(Location location)
        {
            return new LocationDTO
            {
                Postcode = location.Postcode,
                City = location.City,
                Street = location.Street,
                HouseNumberLabel = location.HouseNumberLabel
            };
        }

        public static ContactDTO MapToDTO(Contact contact)
        {
            return new ContactDTO { Phone = contact.Phone, Email = contact.Email };
        }

        public static RestaurantDTO MapToDTO(Restaurant restaurant)
        {
            return new RestaurantDTO
            {
                RestaurantId = restaurant.RestaurantID,
                Name = restaurant.Name,
                Location = MapToDTO(restaurant.Location),
                Cuisine = restaurant.Cuisine,
                Contact = MapToDTO(restaurant.Contact)
            };
        }

        public static ReservationDTO MapToDTO(Reservation reservation)
        {
            return new ReservationDTO
            {
                ReservationId = reservation.ReservationID,
                UserId = reservation.UserId,
                RestaurantId = reservation.RestaurantId,
                ReservationNumber = reservation.ReservationNumber,
                Date = reservation.Date,
                Time = reservation.Time,
                TableNumber = reservation.TableNumber,
                NumberOfSeats = reservation.NumberOfSeats
            };
        }
    }
}
