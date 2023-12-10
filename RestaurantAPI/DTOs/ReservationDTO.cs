namespace RestaurantAPI.DTOs
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
