using CityBreaks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Services
{
    public class SimpleCountryService
    {
        public Task<List<Country>> GetCountries()
        {
            return Task.FromResult(Countries);
        }

        private readonly List<Country> Countries = new()
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
        };
    }
}
