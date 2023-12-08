using BusinessLayer.Model;

namespace BusinessLayer.Interfaces
{
    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void RemoveReservation(Reservation reservation);
    }
}
