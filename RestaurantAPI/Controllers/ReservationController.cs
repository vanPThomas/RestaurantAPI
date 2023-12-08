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

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET api/reservation/1
        [HttpGet("{id}")]
        public ActionResult<ReservationDTO> GetReservation(int id)
        {
            Reservation reservation = _reservationService.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            ReservationDTO reservationDTO = MapToDTO(reservation);

            return Ok(reservationDTO);
        }

        // POST api/reservation
        [HttpPost]
        public ActionResult<ReservationDTO> CreateReservation(
            [FromBody] ReservationDTO reservationDTO
        )
        {
            // Validation logic if needed

            Reservation reservation = MapToDataLayer(reservationDTO);
            _reservationService.AddReservation(reservation);

            return CreatedAtAction(
                nameof(GetReservation),
                new { id = reservation.ReservationID },
                MapToDTO(reservation)
            );
        }

        // PUT api/reservation/1
        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDTO reservationDTO)
        {
            if (id != reservationDTO.ReservationId)
            {
                return BadRequest();
            }

            // Validation logic if needed

            Reservation existingReservation = _reservationService.GetReservationById(id);

            if (existingReservation == null)
            {
                return NotFound();
            }

            Reservation updatedReservation = MapToDataLayer(reservationDTO);
            _reservationService.UpdateReservation(updatedReservation);

            return NoContent();
        }

        // DELETE api/reservation/1
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            Reservation reservation = _reservationService.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _reservationService.RemoveReservation(reservation);

            return NoContent();
        }

        private ReservationDTO MapToDTO(Reservation reservation)
        {
            // Use your mapping function or AutoMapper here
            return ReverseModelMapper.MapToDTO(reservation);
        }

        private Reservation MapToDataLayer(ReservationDTO reservationDTO)
        {
            // Use your mapping function or AutoMapper here
            return ModelMapper.MapToBusinessModel(reservationDTO);
        }
    }
}
