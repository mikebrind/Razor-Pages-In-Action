using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;
        public CityService(CityBreaksContext context) => _context = context;
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
            return city;
        }

        public async Task<City> UpdateAsync(City city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }
    }
}