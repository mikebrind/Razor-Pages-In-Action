using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Pages.PropertyManager
{
    public class DetailsModel : PageModel
    {
        private readonly CityBreaks.Data.CityBreaksContext _context;

        public DetailsModel(CityBreaks.Data.CityBreaksContext context)
        {
            _context = context;
        }

        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Properties
                .Include(p => p.City).FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
