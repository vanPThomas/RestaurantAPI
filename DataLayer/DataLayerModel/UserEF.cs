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
        public UserEF(int userId, string name, string email, string phone, LocationEF location)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Phone = phone;
            Location = location;
        }

        public UserEF(string name, string email, string phone, LocationEF location)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Location = location;
        }

        public UserEF() { }

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
    }
}
