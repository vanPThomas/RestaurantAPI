using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayerModel
{
    public class RestaurantEF
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public LocationEF Location { get; set; }

        [Required]
        public string Cuisine { get; set; }

        [Required]
        public ContactEF Contact { get; set; }

        public List<ReservationEF> Reservations { get; set; }
    }
}
