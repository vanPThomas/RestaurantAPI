using RestaurantAPI.DTOs;

namespace RestaurantAPI.DTOIn
{
    public class UserDTOIn
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public LocationDTO Location { get; set; }
    }
}
