using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Restaurant
    {
        public Restaurant() { }

        public Restaurant(string name, Location location, string cuisine, Contact contact)
        {
            Name = name;
            Location = location;
            Cuisine = cuisine;
            Contact = contact;
        }

        public Restaurant(
            int restaurantID,
            string name,
            Location location,
            string cuisine,
            Contact contact
        )
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                RestaurantID = restaurantID;
                Name = name;
                Location = location;
                Cuisine = cuisine;
                Contact = contact;
            }
            else
            {
                throw new RestaurantException("Restaurant name can not be empty");
            }
        }

        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Cuisine { get; set; }
        public Contact Contact { get; set; }
        public Dictionary<string, bool> TablesToFree = new Dictionary<string, bool>();
    }
}
