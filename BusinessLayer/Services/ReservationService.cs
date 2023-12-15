using BusinessLayer.Exceptions;
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
            try
            {
                // ApplyReservationBusinessLogic(reservation);
                _reservationRepository.Add(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed: AddResevation", ex);
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            try
            {
                _reservationRepository.Update(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed: UpdateResevation", ex);
            }
        }

        public void RemoveReservation(Reservation reservation)
        {
            try
            {
                _reservationRepository.Remove(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed: RemoveReservation", ex);
            }
        }

        private void ApplyReservationBusinessLogic(Reservation reservation)
        {
            reservation.Date = RoundToNearestHalfHour(reservation.Date);

            reservation.Time = TimeSpan.FromMinutes(90);
        }

        private DateTime RoundToNearestHalfHour(DateTime dateTime)
        {
            var minutes = dateTime.Minute;
            var roundedMinutes = 30 * (int)Math.Round((double)minutes / 30);
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hour,
                roundedMinutes,
                0
            );
        }
    }
}
