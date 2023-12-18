using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleAPICommunication
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await GetFreeTablesByRestaurantAsync(1);

            RestaurantDTOIn newRestaurant = new RestaurantDTOIn
            {
                Name = "New Restaurant",
                Cuisine = "New Cuisine",
                Contact = new Contact { Phone = "123-456-7890", Email = "new@example.com" },
                Location = new Location
                {
                    Postcode = "1245",
                    City = "New City",
                    Street = "New Street",
                    HouseNumberLabel = "42"
                }
            };

            await CreateRestaurantAsync(newRestaurant);
        }

        static async Task GetFreeTablesByRestaurantAsync(int restaurantId)
        {
            try
            {
                string url = $"http://localhost:5253/api/Restaurant/{restaurantId}/freetables";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string tablesJson = await response.Content.ReadAsStringAsync();

                    List<string> tables = JsonConvert.DeserializeObject<List<string>>(tablesJson);

                    Console.WriteLine($"Free tables at Restaurant {restaurantId}:");
                    foreach (var table in tables)
                    {
                        Console.WriteLine(table);
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task CreateRestaurantAsync(RestaurantDTOIn restaurant)
        {
            try
            {
                string url = "http://localhost:5253/api/Restaurant/";
                HttpResponseMessage response = await client.PostAsJsonAsync(url, restaurant);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    RestaurantDTO createdRestaurant = JsonConvert.DeserializeObject<RestaurantDTO>(
                        responseBody
                    );

                    Console.WriteLine($"Restaurant created!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
