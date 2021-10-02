using CityBreaks.Data.Configuration;
using CityBreaks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Data
{
    public class CityBreaksContext : IdentityDbContext<CityBreaksUser>
    {
        private readonly ILoggerFactory _loggerFactory;
        public CityBreaksContext(DbContextOptions options) : base(options)
        {
            _loggerFactory = LoggerFactory.Create(builder => {
                builder.AddConsole();
            });
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
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
