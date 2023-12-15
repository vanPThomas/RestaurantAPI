using RestaurantAPI.DTOs;

namespace RestaurantAPI.DTOIn
{
    public class RestaurantDTOIn
    {
        public string Name { get; set; }
        public LocationDTO Location { get; set; }
        public string Cuisine { get; set; }
        public ContactDTO Contact { get; set; }
    }
}
