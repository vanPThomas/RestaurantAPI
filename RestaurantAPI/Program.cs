using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using BusinessLayer.Services;
using DataLayer.Context;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantAPI.DTOs;

namespace RestaurantAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();
            builder.Services.AddScoped<IRepository<Location>, LocationRepository>();
            builder.Services.AddScoped<IRepository<Contact>, ContactRepository>();
            builder.Services.AddScoped<IRepository<User>, UserRepository>();
            builder.Services.AddScoped<IRepository<Restaurant>, RestaurantRepository>();

            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();

            builder.Services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(
                    @"Data Source=HIMEKO\SQLEXPRESS;Initial Catalog=RestaurantAPI;Integrated Security=True; TrustServerCertificate=true"
                );
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
