using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityBreaks.Pages.PropertyManager
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [Display(Name = "Maximum Number Of Guests")]
        public int MaxNumberOfGuests { get; set; }
        [BindProperty]
        [Display(Name = "Day Rate")]
        public decimal DayRate { get; set; }
        [BindProperty]
        [Display(Name = "Smoking Permitted")]
        public bool SmokingPermitted { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        [Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }
        [BindProperty]
        [Display(Name = "City")]
        public int SelectedCity { get; set; }
        public SelectList Cities { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Cities = GetCityOptions();
        }

        public void OnPost()
        {
            Cities = GetCityOptions();
            if (ModelState.IsValid)
            {
                var city = GetCityOptions().First(o => o.Value == SelectedCity.ToString());
                Message = $"You selected {city.Text} with value of {SelectedCity}";
            }
        }

        private SelectList GetCityOptions()
        {
            var cities =  new List<City>    
            {
                new City{ Id = 1, Name = "London"},
                new City{ Id = 2, Name = "Paris" },
                new City{ Id = 3, Name = "New York" },
                new City{ Id = 4, Name = "Rome" },
                new City{ Id = 5, Name = "Dublin" }
            };
            return new SelectList(cities, nameof(City.Id), nameof(City.Name));
        }
    }
}
