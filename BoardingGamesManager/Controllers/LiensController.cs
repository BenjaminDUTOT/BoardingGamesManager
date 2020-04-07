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
    public class LiensController : Controller
    {
        private readonly BddContext _context;

        public LiensController(BddContext context)
        {
            _context = context;
        }

        // GET: Liens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Liens.ToListAsync());
        }

        // GET: Liens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lien = await _context.Liens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lien == null)
            {
                return NotFound();
            }

            return View(lien);
        }

        // GET: Liens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,URl")] Lien lien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lien);
        }

        // GET: Liens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lien = await _context.Liens.FindAsync(id);
            if (lien == null)
            {
                return NotFound();
            }
            return View(lien);
        }

        // POST: Liens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,URl")] Lien lien)
        {
            if (id != lien.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LienExists(lien.ID))
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
            return View(lien);
        }

        // GET: Liens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lien = await _context.Liens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lien == null)
            {
                return NotFound();
            }

            return View(lien);
        }

        // POST: Liens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lien = await _context.Liens.FindAsync(id);
            _context.Liens.Remove(lien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LienExists(int id)
        {
            return _context.Liens.Any(e => e.ID == id);
        }
    }
}
