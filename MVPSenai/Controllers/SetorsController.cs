using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVPSenai.Data;
using MVPSenai.Models;

namespace MVPSenai.Controllers
{
    public class SetorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Setors
        public async Task<IActionResult> Index()
        {
              return _context.setores != null ? 
                          View(await _context.setores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.setores'  is null.");
        }

        // GET: Setors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.setores == null)
            {
                return NotFound();
            }

            var setor = await _context.setores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // GET: Setors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSetor,NomeSetor")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setor);
        }

        // GET: Setors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.setores == null)
            {
                return NotFound();
            }

            var setor = await _context.setores.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }

        // POST: Setors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSetor,NomeSetor")] Setor setor)
        {
            if (id != setor.IdSetor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorExists(setor.IdSetor))
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
            return View(setor);
        }

        // GET: Setors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.setores == null)
            {
                return NotFound();
            }

            var setor = await _context.setores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // POST: Setors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.setores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.setores'  is null.");
            }
            var setor = await _context.setores.FindAsync(id);
            if (setor != null)
            {
                _context.setores.Remove(setor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorExists(int id)
        {
          return (_context.setores?.Any(e => e.IdSetor == id)).GetValueOrDefault();
        }
    }
}
