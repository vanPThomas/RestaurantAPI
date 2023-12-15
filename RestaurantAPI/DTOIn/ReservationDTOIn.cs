namespace RestaurantAPI.DTOIn
{
    public class ReservationDTOIn
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
