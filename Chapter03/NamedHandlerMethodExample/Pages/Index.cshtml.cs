using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedHandlerMethodExample.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public void OnPostSearch(string searchTerm)
        {
            Message = $"You searched for {searchTerm}";
        }

        public void OnPostRegister(string email)
        {
            Message = $"You registered {email} for newsletters";
        }

    }
}
