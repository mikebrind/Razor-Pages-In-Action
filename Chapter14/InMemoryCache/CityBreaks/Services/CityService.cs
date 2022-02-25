using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CityBreaks.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CityService> _logger;

        public CityService(CityBreaksContext context, IMemoryCache cache, ILogger<CityService> logger) 
        { 
            _context = context;
            _cache = cache;
            _logger = logger;
        }
        public async Task<List<City>> GetAllAsync()
        {
            var cities = _context.Cities
                     .Include(c => c.Country)
                     .Include(c => c.Properties.Where(p => p.AvailableFrom < DateTime.Now));
            return await cities.ToListAsync();
        }

        public async Task<City> GetByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties.Where(p => p.AvailableFrom < DateTime.Now))
                .SingleOrDefaultAsync(c => EF.Functions.Collate(c.Name, "NOCASE") == name);
        }

        public async Task<City> GetByIdAsync(int id) =>
           await _context.Cities
           .Include(x => x.Properties)
           .Include(x => x.Country)
           .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<City> CreateAsync(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            _cache.Remove(nameof(GetCityNamesAsync));
            return city;
        }

        public async Task<City> UpdateAsync(City city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
            _cache.Remove(nameof(GetCityNamesAsync));
            return city;
        }

        public async Task<List<string>> GetCityNamesAsync()
        {
            if(_cache.TryGetValue<List<string>>(nameof(GetCityNamesAsync), out var cityNames))
            {
                _logger.LogInformation("Cities retrieved from memory cache");
                return cityNames;
            }
            _cache.Set(nameof(GetCityNamesAsync), await _context.Cities.Select(c => c.Name).ToListAsync());
            _logger.LogInformation("Cache empty. Storing cities in memory cache");
            return _cache.Get<List<string>>(nameof(GetCityNamesAsync)); 
        }
    }
}