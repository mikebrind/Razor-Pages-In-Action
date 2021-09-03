using CityBreaks.Models;

namespace CityBreaks.Services
{
    public interface ICityService
    {
        Task<List<City>> GetCities();
    }
}