using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;
        private readonly ILogger<IndexModel> _logger;
        private readonly IHostEnvironment _environment;
        public IndexModel(ILogger<IndexModel> logger, ICityService cityService, IHostEnvironment environment)
        {
            _logger = logger;
            _cityService = cityService;
            _environment = environment;
        }

        public List<City> Cities { get; set; }
        //public async Task OnGetAsync()
        //{
            
        //    Cities = await _cityService.GetAllAsync();
        //    if (_environment.IsDevelopment())
        //    {
        //        _logger.LogInformation("{count} Cities retrieved", Cities.Count);
        //    }
        //}
    }
}