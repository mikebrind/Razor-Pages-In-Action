namespace CityBreaks.Models
{
    public class Booking
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal DayRate { get; set; }
    }
}
