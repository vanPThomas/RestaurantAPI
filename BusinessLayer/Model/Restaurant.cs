using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Cuisine { get; set; }
        public Contact Contact { get; set; }
    }
}
