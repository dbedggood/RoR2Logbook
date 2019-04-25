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
    public class IndexModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public IndexModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

        public IList<Survivor> Survivor { get;set; }

        public async Task OnGetAsync()
        {
            Survivor = await _context.Survivor.ToListAsync();
        }
    }
}
