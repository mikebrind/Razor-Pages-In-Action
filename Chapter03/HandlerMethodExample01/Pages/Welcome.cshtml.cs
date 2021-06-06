using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandlerMethodExample01.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "OnGet executed";
        }

        public void OnPost()
        {
            Message = "OnPost executed";
        }

    }
}
