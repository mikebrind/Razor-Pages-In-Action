using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages
{
    public class CityModel : PageModel
    {
        public string CityName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public void OnGet(string cityName, DateTime arrivalDate)
        {
            CityName = cityName;
            ArrivalDate = arrivalDate;
        }
    }
}
