using CityBreaks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CityBreaks.Pages.ClaimsManager
{
    public class AssignModel : PageModel
    {
        private readonly UserManager<CityBreaksUser> _userManager;
        public AssignModel(UserManager<CityBreaksUser> userManager)
        {
            _userManager = userManager;
        }

        public SelectList Users { get; set; }
        [BindProperty, Required, Display(Name = "User")]
        public string SelectedUserId { get; set; }
        [BindProperty, Required, Display(Name ="Claim Type")]
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
                var user = await _userManager.FindByIdAsync(SelectedUserId);
                await _userManager.AddClaimAsync(user, claim);
                return RedirectToPage("/ClaimsManager/Index");
            }
            await GetOptions();
            return Page();
        }

        public async Task GetOptions()
        {
            var users = await _userManager.Users.ToListAsync();
            Users = new SelectList(users, nameof(CityBreaksUser.Id), nameof(CityBreaksUser.UserName));
        }
    }
}
