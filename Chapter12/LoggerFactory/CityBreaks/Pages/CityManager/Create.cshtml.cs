using CityBreaks.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Pages.CityManager
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public CreateModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        [UploadFileExtensions(Extensions = ".jpg")]
        public IFormFile Upload { get; set; }
        [TempData]
        public string Photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = Name;
                Photo = $"{Name.ToLower().Replace(" ", "-")}{Path.GetExtension(Upload.FileName)}";
                var filePath = Path.Combine(_environment.WebRootPath, "images", "cities", Photo);
                using var stream = System.IO.File.Create(filePath);
                await Upload.CopyToAsync(stream);
                return RedirectToPage("/CityManager/Index");
            }
            return Page();
        }
    }
}