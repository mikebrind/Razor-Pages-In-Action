using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages;

public class CityModel : PageModel
{
    private readonly ICityService _cityService;
    public CityModel(ICityService cityService)
    {
        _cityService = cityService;
    }

    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }
    public City City { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        City = await _cityService.GetCityByName(Name);
        if(City == null)
        {
            return NotFound();
        }
        return Page();
    }
}

