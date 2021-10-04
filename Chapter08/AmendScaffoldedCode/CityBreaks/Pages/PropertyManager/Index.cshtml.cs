using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages.PropertyManager
{
    public class IndexModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public IndexModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IList<Property> Property { get; set; }

        public async Task OnGetAsync()
        {
            Property = await _propertyService.GetAllAsync();
        }
    }
}