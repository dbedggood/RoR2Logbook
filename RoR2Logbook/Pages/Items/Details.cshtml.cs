using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoR2Logbook.Models;

namespace RoR2Logbook.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public DetailsModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.ID == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
