using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages.PropertyManager
{
    public class DeleteModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public DeleteModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Property Property { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _propertyService.FindAsync(Id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _propertyService.DeleteAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}
