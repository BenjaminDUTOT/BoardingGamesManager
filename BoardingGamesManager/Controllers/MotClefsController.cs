using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardingGamesManager.Models;

namespace BoardingGamesManager.Controllers
{
    public class MotClefsController : Controller
    {
        private readonly BddContext _context;

        public MotClefsController(BddContext context)
        {
            _context = context;
        }

        // GET: MotClefs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MotClefs.ToListAsync());
        }

        // GET: MotClefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motClef = await _context.MotClefs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (motClef == null)
            {
                return NotFound();
            }

            return View(motClef);
        }

        // GET: MotClefs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotClefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Value")] MotClef motClef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motClef);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motClef);
        }

        // GET: MotClefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motClef = await _context.MotClefs.FindAsync(id);
            if (motClef == null)
            {
                return NotFound();
            }
            return View(motClef);
        }

        // POST: MotClefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Value")] MotClef motClef)
        {
            if (id != motClef.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motClef);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotClefExists(motClef.ID))
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
            return View(motClef);
        }

        // GET: MotClefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motClef = await _context.MotClefs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (motClef == null)
            {
                return NotFound();
            }

            return View(motClef);
        }

        // POST: MotClefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motClef = await _context.MotClefs.FindAsync(id);
            _context.MotClefs.Remove(motClef);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotClefExists(int id)
        {
            return _context.MotClefs.Any(e => e.ID == id);
        }
    }
}
