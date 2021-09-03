using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Services;
public class CityService : ICityService
{
    private readonly CityBreaksContext _context;
    public CityService(CityBreaksContext context) => _context = context;
    public async Task<List<City>> GetCities()
    {
        var cities = _context.Cities
                 .Include(c => c.Country)
                 .Include(c => c.Properties);
        return await cities.ToListAsync();
    }
}
