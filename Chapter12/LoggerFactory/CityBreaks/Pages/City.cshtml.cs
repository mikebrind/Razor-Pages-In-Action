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
    private readonly ILoggerFactory _loggerFactory;

    public CityModel(ICityService cityService,
        IPropertyService propertyService,
        ILoggerFactory loggerFactory)
    {
        _cityService = cityService;
        _propertyService = propertyService;
        _loggerFactory = loggerFactory;
    }

    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }
    public City City { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var logger = _loggerFactory.CreateLogger("City Page OnGetAsync");
        City = await _cityService.GetByNameAsync(Name);
        if (City == null)
        {
            logger.LogWarning(404, "City \"{name}\" not found", Name);
            return NotFound();
        }
        logger.LogInformation("City \"{name}\"  found", Name);
        return Page();
    }

    public async Task<PartialViewResult> OnGetPropertyDetails(int id)
    {
        var property = await _propertyService.FindAsync(id);
        var model = new BookingInputModel { Property = property };
        return Partial("_PropertyDetailsPartial", model);
    }

    public JsonResult OnPostBooking([FromBody] BookingInputModel model)
    {
        var numberOfDays = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;
        var totalCost = numberOfDays * model.Property.DayRate * model.NumberOfGuests;
        var result = new { TotalCost = totalCost };
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
