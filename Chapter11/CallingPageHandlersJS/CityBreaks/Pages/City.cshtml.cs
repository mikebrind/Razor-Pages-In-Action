using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages;

public class CityModel : PageModel
{
    private readonly ICityService _cityService;
    private readonly IPropertyService _propertyService;

    public CityModel(ICityService cityService, IPropertyService propertyService)
    {
        _cityService = cityService;
        _propertyService = propertyService;
    }

    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }
    public City City { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        City = await _cityService.GetByNameAsync(Name);
        if (City == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<PartialViewResult> OnGetPropertyDetails(int id)
    {
        var property = await _propertyService.FindAsync(id);
        return Partial("_PropertyDetailsPartial", property);
    }
}
