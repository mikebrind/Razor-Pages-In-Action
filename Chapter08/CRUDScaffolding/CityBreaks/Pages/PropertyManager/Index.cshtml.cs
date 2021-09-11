using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Data;
using CityBreaks.Models;

namespace CityBreaks.Pages.PropertyManager
{
    public class IndexModel : PageModel
    {
        private readonly CityBreaks.Data.CityBreaksContext _context;

        public IndexModel(CityBreaks.Data.CityBreaksContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; }

        public async Task OnGetAsync()
        {
            Property = await _context.Properties
                .Include(p => p.City).ToListAsync();
        }
    }
}
