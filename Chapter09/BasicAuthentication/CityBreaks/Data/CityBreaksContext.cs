using CityBreaks.Data.Configuration;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Data
{
    public class CityBreaksContext : DbContext
    {
        public CityBreaksContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CityConfiguration())
                .ApplyConfiguration(new CountryConfiguration())
                .ApplyConfiguration(new PropertyConfiguration());
        }

    }
}
