using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "OnGet executed";
        }

        public void OnPost()
        {
            Message = "OnPost executed";
        }
    }
}
