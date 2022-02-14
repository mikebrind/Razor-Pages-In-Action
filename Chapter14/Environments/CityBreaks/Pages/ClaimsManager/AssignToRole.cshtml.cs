using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CityBreaks.Pages.ClaimsManager
{
    public class AssignToRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AssignToRoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public SelectList Roles { get; set; }
        [BindProperty, Required, Display(Name = "Role")]
        public string SelectedRoleId { get; set; }
        [BindProperty, Required, Display(Name = "Claim Type")]
        public string ClaimType { get; set; }
        [BindProperty, Display(Name = "Claim Value")]
        public string ClaimValue { get; set; }
        public async Task OnGetAsync()
        {
            await GetOptions();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var claim = new Claim(ClaimType, ClaimValue ?? String.Empty);
                var role = await _roleManager.FindByIdAsync(SelectedRoleId);
                await _roleManager.AddClaimAsync(role, claim);
                return RedirectToPage("/ClaimsManager/Index");
            }
            await GetOptions();
            return Page();
        }

        public async Task GetOptions()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            Roles = new SelectList(roles, nameof(IdentityRole.Id), nameof(IdentityRole.Name));
        }
    }
}
