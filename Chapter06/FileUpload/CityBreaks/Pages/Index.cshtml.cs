using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        [Display(Name = "Cities")]
        public int[] SelectedCities { get; set; }
        public SelectList Cities { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Cities = GetCityOptions();
        }
        public void OnPost()
        {
            Cities = GetCityOptions();
            if (ModelState.IsValid)
            {
                var cityIds = SelectedCities.Select(x => x.ToString());
                var cities = GetCityOptions().Where(o => cityIds.Contains(o.Value)).Select(o=>o.Text);
                Message = $"You selected {string.Join(", ", cities)}";
            }
        }
        private SelectList GetCityOptions()
        {
            var cities = new List<City>
            {
                new City{ Id = 1, Name = "London"},
                new City{ Id = 2, Name = "Paris" },
                new City{ Id = 3, Name = "New York" },
                new City{ Id = 4, Name = "Rome" },
                new City{ Id = 5, Name = "Dublin" }
            };
            return new SelectList(cities, nameof(City.Id), nameof(City.Name));
        }
    }
}
