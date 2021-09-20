using CityBreaks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
    }
}