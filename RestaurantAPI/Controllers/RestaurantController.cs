using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantAPI.DTOs;
using RestaurantAPI.Mappers;
using System;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger _logger;

        public RestaurantController(
            IRestaurantService restaurantService,
            ILoggerFactory loggerFactory
        )
        {
            _restaurantService = restaurantService;
            _logger = loggerFactory
                .AddFile("./Logs/RestaurantLogs/RestaurantLog.txt")
                .CreateLogger("Restaurant");
        }

        // GET api/restaurant/1
        [HttpGet("{id}")]
        public ActionResult<RestaurantDTO> GetRestaurant(int id)
        {
            try
            {
                _logger.LogInformation($"Calling GetRestaurant with ID: {id}");

                Restaurant restaurant = _restaurantService.GetRestaurantById(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                RestaurantDTO restaurantDTO = MapToDTO(restaurant);

                return Ok(restaurantDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing GetRestaurant.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/restaurant
        [HttpPost]
        public ActionResult<RestaurantDTO> CreateRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            try
            {
                _logger.LogInformation("Calling CreateRestaurant");

                Restaurant restaurant = MapToDataLayer(restaurantDTO);
                _restaurantService.AddRestaurant(restaurant);

                return CreatedAtAction(
                    nameof(GetRestaurant),
                    new { id = restaurant.RestaurantID },
                    MapToDTO(restaurant)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing CreateRestaurant.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/restaurant/1
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] RestaurantDTO restaurantDTO)
        {
            try
            {
                _logger.LogInformation($"Calling UpdateRestaurant with ID: {id}");

                if (id != restaurantDTO.RestaurantId)
                {
                    return BadRequest();
                }

                Restaurant existingRestaurant = _restaurantService.GetRestaurantById(id);

                if (existingRestaurant == null)
                {
                    return NotFound();
                }

                Restaurant updatedRestaurant = MapToDataLayer(restaurantDTO);
                _restaurantService.UpdateRestaurant(updatedRestaurant);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing UpdateRestaurant.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/restaurant/1
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            try
            {
                _logger.LogInformation($"Calling DeleteRestaurant with ID: {id}");

                Restaurant restaurant = _restaurantService.GetRestaurantById(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                _restaurantService.RemoveRestaurant(restaurant);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing DeleteRestaurant.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //GET api/restaurant/1/reservations
        [Route("{id}/reservations")]
        [HttpGet]
        public ActionResult<List<ReservationDTO>> GetReservationsByRestaurant(int id)
        {
            try
            {
                _logger.LogInformation($"Calling GetReservationsByRestaurant with ID: {id}");

                Restaurant restaurant = _restaurantService.GetRestaurantById(id);

                if (restaurant == null)
                {
                    return NotFound();
                }
                List<ReservationDTO> reservations = new List<ReservationDTO>();
                foreach (Reservation reservation in restaurant.Reservations)
                {
                    ReservationDTO rDTO = MapToDTO(reservation);
                    reservations.Add(rDTO);
                }

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing GetReservationsByRestaurant.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        private RestaurantDTO MapToDTO(Restaurant restaurant)
        {
            return ReverseModelMapper.MapToDTO(restaurant);
        }

        private Restaurant MapToDataLayer(RestaurantDTO restaurantDTO)
        {
            return ModelMapper.MapToBusinessModel(restaurantDTO);
        }

        private ReservationDTO MapToDTO(Reservation reservation)
        {
            return ReverseModelMapper.MapToDTO(reservation);
        }
    }
}
