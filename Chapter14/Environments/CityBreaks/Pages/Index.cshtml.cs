using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;
        private ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        public List<City> Cities { get; set; }
        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
            _logger.LogInformation("{count} Cities retrieved", Cities.Count);
        }
    }
}