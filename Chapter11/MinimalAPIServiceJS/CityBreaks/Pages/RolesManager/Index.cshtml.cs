using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages.RoleManager
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager  = roleManager;
        }
        public List<IdentityRole> Roles { get; set; }   
        public void OnGet()
        {
            Roles = _roleManager.Roles.ToList();
        }
    }
}
