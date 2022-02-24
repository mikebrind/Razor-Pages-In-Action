using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityBreaks.ViewComponents
{
    public class CitiesViewComponent : ViewComponent
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CitiesViewComponent> _logger;

        public CitiesViewComponent(ICityService cityService, ILogger<CitiesViewComponent> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await _cityService.GetAllAsync();
            _logger.LogInformation("Cities retrieved from the view component at {now}", DateTime.Now.ToLongTimeString());
            return View(cities);
        }
    }
}
