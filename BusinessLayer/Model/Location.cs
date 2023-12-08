using BusinessLayer.Exceptions;

namespace BusinessLayer.Model
{
    public class Location
    {
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumberLabel { get; set; }

        public Location(
            string postcode,
            string city,
            string street = null,
            string houseNumberLabel = null
        )
        {
            if (postcode.Length != 4 || !postcode.All(char.IsDigit))
            {
                throw new LocationException("Postcode must contain 4 digits.");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new LocationException("City is required and cannot be empty.");
            }

            Postcode = postcode;
            City = city;
            Street = street;
            HouseNumberLabel = houseNumberLabel;
        }
    }
}
