using CityBreaks.Models;

namespace CityBreaks.Services
{
    public interface IBookingService
    {
        decimal Calculate(Booking booking);
    }
}