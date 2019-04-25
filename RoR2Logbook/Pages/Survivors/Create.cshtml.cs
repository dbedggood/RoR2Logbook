using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoR2Logbook.Models;

namespace RoR2Logbook.Pages.Survivors
{
    public class CreateModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public CreateModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Survivor Survivor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Survivor.Add(Survivor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}