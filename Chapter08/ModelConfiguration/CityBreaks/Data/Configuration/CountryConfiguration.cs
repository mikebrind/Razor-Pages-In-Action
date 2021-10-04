using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.CountryName)
                .HasMaxLength(50);
            builder.Property(x => x.CountryCode)
                .HasColumnName("ISO 3166 code")
                .HasMaxLength(2);
        }
    }
}