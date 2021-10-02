using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configuration;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Photo).HasColumnName("Image");
        builder.HasData(new List<City>
        {
            new City { Id = 1, Name = "Amsterdam", CountryId = 5, Photo = "amsterdam.jpg" },
            new City { Id = 2, Name = "Barcelona", CountryId = 7, Photo ="barcelona.jpg" },
            new City { Id = 3, Name = "Berlin", CountryId = 4, Photo ="berlin.jpg" },
            new City { Id = 4, Name = "Copenhagen", CountryId = 2, Photo ="copenhagen.jpg" },
            new City { Id = 5, Name = "Dubrovnik", CountryId = 1, Photo ="dubrovnik.jpg" },
            new City { Id = 6, Name = "Edinburgh", CountryId = 8, Photo ="edinburgh.jpg" },
            new City { Id = 7, Name = "London", CountryId = 8, Photo ="london.jpg" },
            new City { Id = 8, Name = "Madrid", CountryId = 7, Photo ="madrid.jpg" },
            new City { Id = 9, Name = "New York", CountryId = 9, Photo ="new-york.jpg" },
            new City { Id = 10, Name = "Paris", CountryId = 3, Photo ="paris.jpg" },
            new City { Id = 11, Name = "Rome", CountryId = 6, Photo ="rome.jpg" },
            new City { Id = 12, Name = "Venice", CountryId = 6, Photo ="venice.jpg" }
        });
    }
}
