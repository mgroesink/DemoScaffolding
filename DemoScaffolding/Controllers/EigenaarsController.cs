using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoScaffolding.Data;
using DemoScaffolding.Models;

namespace DemoScaffolding.Controllers
{
    public class EigenaarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EigenaarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eigenaars
        public async Task<IActionResult> Index()
        {
              return _context.Eigenaren != null ? 
                          View(await _context.Eigenaren.Include(e=>e.Autos).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Eigenaren'  is null.");
        }

        // GET: Eigenaars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eigenaren == null)
            {
                return NotFound();
            }

            var eigenaar = await _context.Eigenaren.Include(e => e.Autos)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eigenaar == null)
            {
                return NotFound();
            }

            return View(eigenaar);
        }

        // GET: Eigenaars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eigenaars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naam,Postcode,Adres,Plaats")] Eigenaar eigenaar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eigenaar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eigenaar);
        }

        // GET: Eigenaars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eigenaren == null)
            {
                return NotFound();
            }

            var eigenaar = await _context.Eigenaren.FindAsync(id);
            if (eigenaar == null)
            {
                return NotFound();
            }
            return View(eigenaar);
        }

        // POST: Eigenaars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naam,Postcode,Adres,Plaats")] Eigenaar eigenaar)
        {
            if (id != eigenaar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eigenaar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EigenaarExists(eigenaar.ID))
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
            return View(eigenaar);
        }

        // GET: Eigenaars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eigenaren == null)
            {
                return NotFound();
            }

            var eigenaar = await _context.Eigenaren
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eigenaar == null)
            {
                return NotFound();
            }

            return View(eigenaar);
        }

        // POST: Eigenaars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eigenaren == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Eigenaren'  is null.");
            }
            var eigenaar = await _context.Eigenaren.FindAsync(id);
            if (eigenaar != null)
            {
                _context.Eigenaren.Remove(eigenaar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EigenaarExists(int id)
        {
          return (_context.Eigenaren?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
