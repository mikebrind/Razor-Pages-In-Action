
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configuration;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.CountryName)
            .HasMaxLength(50);
        builder.Property(x => x.CountryCode)
            .HasColumnName("ISO 3166 code")
            .HasMaxLength(2);
        builder.HasData(new List<Country>
        {
            new Country {Id = 1, CountryName = "Croatia", CountryCode="hr" },
            new Country {Id = 2, CountryName = "Denmark", CountryCode =  "dk" },
            new Country {Id = 3, CountryName = "France", CountryCode = "fr" },
            new Country {Id = 4, CountryName = "Germany", CountryCode = "de" },
            new Country {Id = 5, CountryName = "Holland", CountryCode = "nl" },
            new Country {Id = 6, CountryName = "Italy", CountryCode = "it" },
            new Country {Id = 7, CountryName = "Spain", CountryCode = "es" },
            new Country {Id = 8, CountryName = "United Kingdom", CountryCode = "gb" },
            new Country {Id = 9, CountryName = "United States", CountryCode = "us" }
        });
    }
}
