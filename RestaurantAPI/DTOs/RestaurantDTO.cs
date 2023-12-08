namespace RestaurantAPI.DTOs
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public LocationDTO Location { get; set; }
        public string Cuisine { get; set; }
        public ContactDTO Contact { get; set; }
    }
}
