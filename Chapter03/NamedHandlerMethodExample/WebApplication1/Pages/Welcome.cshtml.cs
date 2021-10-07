using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Message { get; set; }
        public void OnPostSearch(string searchTerm)
        {
            Message = $"You searched for {searchTerm}";
        }

        public void OnPostRegister(string email)
        {
            Message = $"You registered {email} for newsletters";
        }
    }
}
