using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityBreaks.AuthorizationRequirements;
using CityBreaks.Data;
using CityBreaks.Models;
using CityBreaks.Services;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages.PropertyManager
{
public class EditModel : PageModel
{
    private readonly IPropertyService _propertyService;
    private readonly ICityService _cityService;
    private readonly IAuthorizationService _authService;

    public EditModel(IPropertyService propertyService, 
                ICityService cityService, 
                IAuthorizationService authService)
    {
        _propertyService = propertyService;
        _cityService = cityService;
        _authService = authService;
    }

        public SelectList Cities { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty, Display(Name = "City")]
        public int CityId { get; set; }
        [BindProperty, Required]
        public string Name { get; set; }
        [BindProperty, Required]
        public string Address { get; set; }
        [BindProperty, Display(Name = "Maximum Number Of Guests")]
        public int MaxNumberOfGuests { get; set; }
        [BindProperty, Display(Name = "Daily Rate")]
        public decimal DayRate { get; set; }
        [BindProperty, Display(Name = "Smoking?")]
        public bool SmokingPermitted { get; set; }
        [BindProperty, Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var property = await _propertyService.FindAsync(Id);

            if (property == null)
            {
                return NotFound();
            }
            var result = await _authService.AuthorizeAsync(User, property, PropertyOperations.Edit);
            if (!result.Succeeded) 
            { 
                return Forbid();
            }
            Address = property.Address;
            AvailableFrom = property.AvailableFrom;
            CityId = property.CityId;
            DayRate = property.DayRate;
            MaxNumberOfGuests = property.MaxNumberOfGuests;
            Name = property.Name;
            SmokingPermitted = property.SmokingPermitted;

            Cities = await GetCityOptions();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Cities = await GetCityOptions();
                return Page();
            }

            var property = new Property
            {
                Address = Address,
                AvailableFrom = AvailableFrom,
                CityId = CityId,
                DayRate = DayRate,
                Id = Id,
                MaxNumberOfGuests = MaxNumberOfGuests,
                Name = Name,
                SmokingPermitted = SmokingPermitted
            };
            await _propertyService.UpdateAsync(property);

            return RedirectToPage("./Index");
        }

        private async Task<SelectList> GetCityOptions()
        {
            var cities = await _cityService.GetAllAsync();
            return new SelectList(cities, nameof(City.Id), nameof(City.Name));
        }
    }
}