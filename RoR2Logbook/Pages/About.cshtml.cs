using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoR2Logbook.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public string Test { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
            Test = "Test Message";
        }
    }
}
