using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayerModel
{
    public class LocationEF
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string City { get; set; }

        public string Street { get; set; }
        public string HouseNumberLabel { get; set; }
    }
}
