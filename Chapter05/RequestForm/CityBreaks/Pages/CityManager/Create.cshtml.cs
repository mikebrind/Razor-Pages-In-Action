using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace CityBreaks.Pages.CityManager
{
    public class CreateModel : PageModel
    {
        public string Message { get; set; }
        public void OnPost()
        {
            if (!StringValues.IsNullOrEmpty(Request.Form["cityName"]))
            {
                Message = $"You submitted {Request.Form["cityName"]}";
            }
        }
    }
}