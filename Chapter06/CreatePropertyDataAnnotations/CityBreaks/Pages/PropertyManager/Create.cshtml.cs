using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages.PropertyManager
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [Display(Name = "Maximum Number Of Guests")]
        public int MaxNumberOfGuests { get; set; }
        [BindProperty]
        [Display(Name = "Day Rate")]
        public decimal DayRate { get; set; }
        [BindProperty]
        [Display(Name = "Smoking Permitted")]
        public bool SmokingPermitted { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        [Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }

        public void OnGet()
        {
        }
    }
}