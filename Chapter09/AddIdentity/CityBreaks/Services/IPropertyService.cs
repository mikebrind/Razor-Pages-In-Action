
using CityBreaks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Services
{
    public interface IPropertyService
    {
        Task<Property> CreateAsync(Property property);
        Task<List<Property>> GetAllAsync();
        Task<Property> FindAsync(int id);
        Task<Property> UpdateAsync(Property property);
        Task DeleteAsync(int id);
    }
}