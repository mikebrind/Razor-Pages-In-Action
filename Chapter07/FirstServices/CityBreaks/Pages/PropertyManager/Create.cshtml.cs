using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        [BindProperty, Required]
        public Rating Rating { get; set; }
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Cities = await GetCityOptions();
        }

        public async Task OnPostAsync()
        {
            Cities = await GetCityOptions();
            if (ModelState.IsValid)
            {
                var city = Cities.First(o => o.Value == SelectedCity.ToString());
                Message = $"You selected {city.Text} with value of {SelectedCity}";
            }
        }

        private async Task<SelectList> GetCityOptions()
        {
            var service = new SimpleCityService();
            var cities = await service.GetAllAsync();
            return new SelectList(cities, nameof(City.Id), nameof(City.Name), null, "Country.CountryName");
        }
    }
}