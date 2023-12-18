using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPICommunication
{
    public class RestaurantDTOIn
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
    }
}
