using CityBreaks.Models;

namespace CityBreaks.Services
{
    public class BookingService : IBookingService
    {
        public decimal Calculate(Booking booking)
        {
            var numberOfDays = (int)(booking.EndDate - booking.StartDate).TotalDays;
            var totalCost = numberOfDays * booking.DayRate * booking.NumberOfGuests;
            return totalCost;
        }
    }
}
