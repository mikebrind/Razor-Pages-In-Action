using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandlerParameterExample.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(int id)
        {
            Message = $"OnGet executed with id = {id}";
        }
    }
}
