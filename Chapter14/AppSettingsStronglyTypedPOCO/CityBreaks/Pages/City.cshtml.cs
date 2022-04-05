using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages;


public class CityModel : PageModel
{
    private readonly ICityService _cityService;
    private readonly IPropertyService _propertyService;
    private readonly ILogger<CityModel> _logger;

    public CityModel(ICityService cityService,
        IPropertyService propertyService,
        ILogger<CityModel> logger)
    {
        _cityService = cityService;
        _propertyService = propertyService;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }
    public City City { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        City = await _cityService.GetByNameAsync(Name);
        if (City == null)
        {
            _logger.LogWarning("City \"{name}\" not found", Name);
            return NotFound();
        }
        _logger.LogInformation("City \"{name}\"  found", Name);
        return Page();
    }

public async Task<PartialViewResult> OnGetPropertyDetails(int id)
{
    var property = await _propertyService.FindAsync(id);
    _logger.LogInformation("Property {@property} retrieved by {user}", property, User.Identity.Name);
    var model = new BookingInputModel { Property = property };
    return Partial("_PropertyDetailsPartial", model);
}

    public JsonResult OnPostBooking([FromBody]BookingInputModel model)
    {
        var numberOfDays = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;
        var totalCost = numberOfDays * model.Property.DayRate * model.NumberOfGuests;
        var result = new  { TotalCost = totalCost };
        return new JsonResult(result);
    }

    public class BookingInputModel
    {
        public Property Property { get; set; }
        [Display(Name = "No. of guests")]
        public int NumberOfGuests { get; set; }
        [DataType(DataType.Date), Display(Name = "Arrival")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Departure")]
        public DateTime? EndDate { get; set; }
    }
}
