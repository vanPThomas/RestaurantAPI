using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Mappers; // Assuming you have a Mappers namespace

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET api/restaurant/1
        [HttpGet("{id}")]
        public ActionResult<RestaurantDTO> GetRestaurant(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            RestaurantDTO restaurantDTO = MapToDTO(restaurant);

            return Ok(restaurantDTO);
        }

        // POST api/restaurant
        [HttpPost]
        public ActionResult<RestaurantDTO> CreateRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            // Validation logic if needed

            Restaurant restaurant = MapToDataLayer(restaurantDTO);
            _restaurantService.AddRestaurant(restaurant);

            return CreatedAtAction(
                nameof(GetRestaurant),
                new { id = restaurant.RestaurantID },
                MapToDTO(restaurant)
            );
        }

        // PUT api/restaurant/1
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] RestaurantDTO restaurantDTO)
        {
            if (id != restaurantDTO.RestaurantId)
            {
                return BadRequest();
            }

            // Validation logic if needed

            Restaurant existingRestaurant = _restaurantService.GetRestaurantById(id);

            if (existingRestaurant == null)
            {
                return NotFound();
            }

            Restaurant updatedRestaurant = MapToDataLayer(restaurantDTO);
            _restaurantService.UpdateRestaurant(updatedRestaurant);

            return NoContent();
        }

        // DELETE api/restaurant/1
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantService.RemoveRestaurant(restaurant);

            return NoContent();
        }

        private RestaurantDTO MapToDTO(Restaurant restaurant)
        {
            // Use your mapping function or AutoMapper here
            return ReverseModelMapper.MapToDTO(restaurant);
        }

        private Restaurant MapToDataLayer(RestaurantDTO restaurantDTO)
        {
            // Use your mapping function or AutoMapper here
            return ModelMapper.MapToBusinessModel(restaurantDTO);
        }
    }
}
