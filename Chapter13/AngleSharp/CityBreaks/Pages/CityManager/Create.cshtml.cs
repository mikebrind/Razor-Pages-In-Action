using AngleSharp;
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
        public string Description { get; set; }
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
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(Description));
            if (document.QuerySelectorAll("script").Any())
            {
                ModelState.AddModelError("Description", "You must not include script tags");
            }

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