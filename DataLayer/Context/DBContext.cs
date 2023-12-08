using BusinessLayer.Model;
using DataLayer.DataLayerModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataLayer.Context
{
    public class DBContext : DbContext
    {
        string mainDb =
            "Data Source=HIMEKO\\SQLEXPRESS;Initial Catalog=RestaurantAPI;Integrated Security=True; TrustServerCertificate=true";

        // DbSet properties for your models
        public DbSet<ContactEF> Contacts { get; set; }
        public DbSet<LocationEF> Locations { get; set; }
        public DbSet<ReservationEF> Reservations { get; set; }
        public DbSet<RestaurantEF> Restaurants { get; set; }
        public DbSet<UserEF> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(mainDb);
        }
    }
}
