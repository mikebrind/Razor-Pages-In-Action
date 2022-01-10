using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService) =>
            _cityService = cityService;
        
        public List<City> Cities { get; set; }
        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
            throw new ApplicationException("Testing status code 500");
        }
    }
}