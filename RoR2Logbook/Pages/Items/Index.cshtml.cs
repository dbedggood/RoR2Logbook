using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoR2Logbook.Models;

namespace RoR2Logbook.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RoR2Logbook.Models.RoR2LogbookContext _context;

        public IndexModel(RoR2Logbook.Models.RoR2LogbookContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemType { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Item
                                           orderby m.Type
                                           select m.Type;

            var items = from m in _context.Item
                        select m;

            if (!string.IsNullOrEmpty(Search))
            {
                items = items.Where(s => s.Name.Contains(Search) || s.Description.Contains(Search));
            }

            if (!string.IsNullOrEmpty(ItemType))
            {
                items = items.Where(x => x.Type == ItemType);
            }

            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Item = await items.ToListAsync();

        }
    }
}
