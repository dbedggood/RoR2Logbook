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
    public class SurvivorsController : Controller
    {
        private readonly RoR2LogbookMVCContext _context;

        public SurvivorsController(RoR2LogbookMVCContext context)
        {
            _context = context;
        }

        // GET: Survivors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Survivor.ToListAsync());
        }

        // GET: Survivors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survivor = await _context.Survivor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (survivor == null)
            {
                return NotFound();
            }

            return View(survivor);
        }

        // GET: Survivors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Survivors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Icon,BaseMaxHealth,MaxHealthIncrease,BaseDamage,DamageIncrease,Speed,Challenge,Notes")] Survivor survivor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survivor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(survivor);
        }

        // GET: Survivors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survivor = await _context.Survivor.FindAsync(id);
            if (survivor == null)
            {
                return NotFound();
            }
            return View(survivor);
        }

        // POST: Survivors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Icon,BaseMaxHealth,MaxHealthIncrease,BaseDamage,DamageIncrease,Speed,Challenge,Notes")] Survivor survivor)
        {
            if (id != survivor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survivor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurvivorExists(survivor.ID))
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
            return View(survivor);
        }

        // GET: Survivors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survivor = await _context.Survivor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (survivor == null)
            {
                return NotFound();
            }

            return View(survivor);
        }

        // POST: Survivors/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survivor = await _context.Survivor.FindAsync(id);
            _context.Survivor.Remove(survivor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurvivorExists(int id)
        {
            return _context.Survivor.Any(e => e.ID == id);
        }
    }
}
