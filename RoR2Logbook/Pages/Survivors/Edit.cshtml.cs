using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoR2Logbook.Models;

namespace RoR2Logbook.Pages.Survivors
{
    public class EditModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public EditModel(RoR2Logbook.Models.RoR2LogbookContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Survivor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurvivorExists(Survivor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SurvivorExists(int id)
        {
            return _context.Survivor.Any(e => e.ID == id);
        }
    }
}
