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
    public class DetailsModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public DetailsModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

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
    }
}
