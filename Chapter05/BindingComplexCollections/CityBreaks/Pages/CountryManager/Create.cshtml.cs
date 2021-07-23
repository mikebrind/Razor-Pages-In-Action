using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CityBreaks.Pages.CountryManager
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Inputs { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();

        public void OnPost()
        {
            Countries = Inputs
                .Where(x => !string.IsNullOrWhiteSpace(x.CountryCode))
                .Select(x => new Country
                {
                    CountryCode = x.CountryCode,
                    CountryName = x.CountryName
                }).ToList();
        }

        public class InputModel
        {
            public string CountryName { get; set; }
            public string CountryCode { get; set; }

        }
    }
}
