using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(int id)
        {
            Message = $"OnGet executed with id = {id}";
        }
    }
}
