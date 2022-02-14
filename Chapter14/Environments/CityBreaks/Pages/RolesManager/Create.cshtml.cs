using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages.RolesManager
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Name { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = Name };
                await _roleManager.CreateAsync(role);
                return RedirectToPage("/RolesManager/Index");
            }
            return Page();
        }
    }
}
