using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Data;
using CityBreaks.Models;

namespace CityBreaks.Pages.PropertyManager
{
    public class CreateModel : PageModel
    {
        private readonly CityBreaks.Data.CityBreaksContext _context;

        public CreateModel(CityBreaks.Data.CityBreaksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
