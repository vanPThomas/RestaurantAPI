using BusinessLayer.Interfaces;
using BusinessLayer.Model;

namespace BusinessLayer.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation GetReservationById(int reservationId)
        {
            Reservation reservation = _reservationRepository.GetById(reservationId);
            return reservation;
        }

        public void AddReservation(Reservation reservation)
        {
            // Additional business logic or validation can be added here
            _reservationRepository.Add(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }

        public void RemoveReservation(Reservation reservation)
        {
            // Additional business logic or validation can be added here
            _reservationRepository.Remove(reservation);
        }
    }
}
