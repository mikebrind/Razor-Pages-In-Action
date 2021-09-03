using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages;

public class LifetimeDemoModel : PageModel
{
    private readonly SingletonService _service;
    
    public LifetimeDemoModel(SingletonService service)
    {
        _service = service;
    }

    public Guid Value { get; set; }
    public void OnGet()
    {
        Value = _service.DependencyValue;
        
    }
}
