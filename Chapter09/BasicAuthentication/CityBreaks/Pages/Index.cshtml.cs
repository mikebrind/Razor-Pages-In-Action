using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public List<City> Cities { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                Cities = await _cityService.GetAllAsync();
                return Page();
            }
            return Challenge();
        }
    }
}