using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayerModel
{
    public class UserEF
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public LocationEF Location { get; set; }

        public void Register() { /* Implementation */
        }

        public void UpdateProfile() { /* Implementation */
        }

        public void Unsubscribe() { /* Implementation */
        }
    }
}
