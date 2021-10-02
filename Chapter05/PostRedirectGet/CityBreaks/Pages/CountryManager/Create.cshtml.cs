using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages.CountryManager
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string CountryCode { get; set; }
        [TempData]
        public string CountryName { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CountryCode = Input.CountryCode;
                CountryName = Input.CountryName;
                return RedirectToPage("/CountryManager/Success");
            }
            return Page();
        }

        public class InputModel
        {
            [Required]
            public string CountryName { get; set; }
            [Required, StringLength(2, MinimumLength = 2,
                ErrorMessage = "You must provide a valid two character ISO 3166-1 code")]
            public string CountryCode { get; set; }
        }
    }
}