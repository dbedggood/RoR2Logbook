using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoR2LogbookMVC.Models;

namespace RoR2LogbookMVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly RoR2LogbookMVCContext _context;

        public ItemsController(RoR2LogbookMVCContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string search, string sort)
        {
            var items = from i in _context.Item
                         select i;

            items = items.OrderBy(s => s.OrderNo);

            ViewData["CurrentFilter"] = search;

            if (sort == "nameDescending")
            {
                items = items.OrderByDescending(s => s.Name);
            }
            else if (sort == "nameAscending")
            {
                items = items.OrderBy(s => s.Name);
            }
            else if (sort == "orderDescending")
            {
                items = items.OrderByDescending(s => s.OrderNo);
            }
            else if (sort == "orderAscending")
            {
                items = items.OrderBy(s => s.OrderNo);
            }

            if (!String.IsNullOrEmpty(search))
            {
                // Select items that contain the search string in their name or description.
                items = items.Where(s => s.Name.Contains(search) || s.Description.Contains(search));
            }

            return View(await items.ToListAsync());
        }

        // GET: Items/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Icon,Name,OrderNo,Type,PickupText,Description,Challenge,Notes")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/{id}
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Icon,Name,OrderNo,Type,PickupText,Description,Challenge,Notes")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/{id}
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ID == id);
        }
    }
}
