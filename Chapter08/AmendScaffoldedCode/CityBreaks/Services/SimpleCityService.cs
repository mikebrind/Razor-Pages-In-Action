using CityBreaks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Services
{
    public class SimpleCityService : ICityService
    {
        public Task<List<City>> GetAllAsync()
        {
            return Task.FromResult(Cities);
        }

        public Task<City> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<City> CreateAsync(City city)
        {
            throw new NotImplementedException();
        }

        public Task<City> UpdateAsync(City city)
        {
            throw new NotImplementedException();
        }

        private readonly List<City> Cities = new()
        {
            new City
            {
                Id = 1,
                Name = "Amsterdam",
                Country = new Country
                {
                    Id = 5,
                    CountryName = "Holland",
                    CountryCode = "nl"
                }
            },
            new City
            {
                Id = 2,
                Name = "Barcelona",
                Country = new Country
                {
                    Id = 7,
                    CountryName = "Spain",
                    CountryCode = "es"
                }
            },
            new City
            {
                Id = 3,
                Name = "Berlin",
                Country = new Country
                {
                    Id = 4,
                    CountryName = "Germany",
                    CountryCode = "de"
                }
            },
            new City
            {
                Id = 4,
                Name = "Copenhagen",
                Country = new Country
                {
                    Id = 2,
                    CountryName = "Denmark",
                    CountryCode = "dk"
                }
            },
            new City
            {
                Id = 5,
                Name = "Dubrovnik",
                Country = new Country
                {
                    Id = 1,
                    CountryName = "Croatia",
                    CountryCode = "hr"
                }
            },
            new City
            {
                Id = 6,
                Name = "Edinburgh",
                Country = new Country
                {
                    Id = 8,
                    CountryName = "United Kingdom",
                    CountryCode = "gb"
                }
            },
            new City
            {
                Id = 7,
                Name = "London",
                Country = new Country
                {
                    Id = 8,
                    CountryName = "United Kingdom",
                    CountryCode = "gb"
                }
            },
            new City
            {
                Id = 8,
                Name = "Madrid",
                Country = new Country
                {
                    Id = 7,
                    CountryName = "Spain",
                    CountryCode = "es"
                }
            },
            new City
            {
                Id = 9,
                Name = "New York",
                Country = new Country
                {
                    Id = 9,
                    CountryName = "United States",
                    CountryCode = "us"
                }
            },
            new City
            {
                Id = 10,
                Name = "Paris",
                Country = new Country
                {
                    Id = 3,
                    CountryName = "France",
                    CountryCode = "fr"
                }
            },
            new City
            {
                Id = 11,
                Name = "Rome",
                Country = new Country
                {
                    Id = 6,
                    CountryName = "Italy",
                    CountryCode = "it"
                }
            },
            new City
            {
                Id = 12,
                Name = "Venice",
                Country = new Country
                {
                    Id = 6,
                    CountryName = "Italy",
                    CountryCode = "it"
                }
            }
        };
    }
}
