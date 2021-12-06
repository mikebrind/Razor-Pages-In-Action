using CityBreaks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages.RolesManager
{
    [Authorize(Roles ="Admin")]
    public class AssignModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CityBreaksUser> _userManager;
        public AssignModel(RoleManager<IdentityRole> roleManager, UserManager<CityBreaksUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public SelectList Roles { get; set; }
        public SelectList Users { get; set; }
        [BindProperty, Required, Display(Name ="Role")]
        public string SelectedRole { get; set; }
        [BindProperty, Required, Display(Name ="User")]
        public string SelectedUser { get; set; }
        public async Task OnGet()
        {
            await GetOptions();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(SelectedUser);
                await _userManager.AddToRoleAsync(user, SelectedRole);
                return RedirectToPage("/RolesManager/Index");
            }
            await GetOptions();
            return Page();
        }

        public async Task GetOptions()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var users = await _userManager.Users.ToListAsync();
            Roles = new SelectList(roles, nameof(IdentityRole.Name));
            Users = new SelectList(users, nameof(CityBreaksUser.UserName));
        }
    }
}
