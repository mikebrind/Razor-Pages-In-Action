
using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Services;
public class PropertyService : IPropertyService
{
    private readonly CityBreaksContext _context;

    public PropertyService(CityBreaksContext context) =>
        _context = context;

    public async Task<List<Property>> GetAllAsync() =>
        await _context.Properties
        .Where(p => !p.Deleted.HasValue)
        .Include(x => x.City)
        .ToListAsync();

    public async Task<Property> FindAsync(int id) =>
        await _context.Properties.FindAsync(id);

    public async Task<Property> CreateAsync(Property property)
    {
        _context.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Property> UpdateAsync(Property property)
    {
        _context.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task DeleteAsync(int id)
    {
        var property = new Property { Id = id, Deleted = DateTime.Now };
        _context.Attach(property).Property(p => p.Deleted).IsModified = true;
        await _context.SaveChangesAsync();
    }
}
