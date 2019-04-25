using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoR2Logbook.Models;

namespace RoR2Logbook.Pages.Survivors
{
    public class DeleteModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public DeleteModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Survivor Survivor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Survivor = await _context.Survivor.FirstOrDefaultAsync(m => m.ID == id);

            if (Survivor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Survivor = await _context.Survivor.FindAsync(id);

            if (Survivor != null)
            {
                _context.Survivor.Remove(Survivor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
