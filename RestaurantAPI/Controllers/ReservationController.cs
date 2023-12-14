using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Mappers;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger _logger;

        public ReservationController(
            IReservationService reservationService,
            ILoggerFactory loggerFactory
        )
        {
            _reservationService = reservationService;
            _logger = loggerFactory
                .AddFile("./Logs/ReservationLogs/ReservationLog.txt")
                .CreateLogger("Reservation");
        }

        // GET api/reservation/1
        [HttpGet("{id}")]
        public ActionResult<ReservationDTO> GetReservation(int id)
        {
            try
            {
                _logger.LogInformation($"Calling GetReservation with ID: {id}");

                Reservation reservation = _reservationService.GetReservationById(id);

                if (reservation == null)
                {
                    return NotFound();
                }

                ReservationDTO reservationDTO = MapToDTO(reservation);

                return Ok(reservationDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing GetReservation.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/reservation
        [HttpPost]
        public ActionResult<ReservationDTO> CreateReservation(
            [FromBody] ReservationDTO reservationDTO
        )
        {
            try
            {
                _logger.LogInformation("Calling CreateReservation");
                Reservation reservation = MapToDataLayer(reservationDTO);
                _reservationService.AddReservation(reservation);

                return CreatedAtAction(
                    nameof(GetReservation),
                    new { id = reservation.ReservationID },
                    MapToDTO(reservation)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing CreateReservation.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/reservation/1
        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDTO reservationDTO)
        {
            try
            {
                _logger.LogInformation($"Calling UpdateReservation with ID: {id}");

                if (id != reservationDTO.ReservationId)
                {
                    return BadRequest();
                }
                Reservation existingReservation = _reservationService.GetReservationById(id);

                if (existingReservation == null)
                {
                    return NotFound();
                }

                Reservation updatedReservation = MapToDataLayer(reservationDTO);
                _reservationService.UpdateReservation(updatedReservation);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing UpdateReservation.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/reservation/1
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            try
            {
                _logger.LogInformation($"Calling DeleteReservation with ID: {id}");

                Reservation reservation = _reservationService.GetReservationById(id);

                if (reservation == null)
                {
                    return NotFound();
                }

                _reservationService.RemoveReservation(reservation);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing DeleteReservation.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        private ReservationDTO MapToDTO(Reservation reservation)
        {
            return ReverseModelMapper.MapToDTO(reservation);
        }

        private Reservation MapToDataLayer(ReservationDTO reservationDTO)
        {
            return ModelMapper.MapToBusinessModel(reservationDTO);
        }
    }
}
