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
    public class LogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.logs.Include(l => l.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.logs == null)
            {
                return NotFound();
            }

            var logs = await _context.logs
                .Include(l => l.Funcionario)
                .FirstOrDefaultAsync(m => m.IdLogs == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.funcionarios, "IdFuncionario", "Email");
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLogs,FuncionarioId,Data,HorasTrabalhadas")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.funcionarios, "IdFuncionario", "Email", logs.FuncionarioId);
            return View(logs);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.logs == null)
            {
                return NotFound();
            }

            var logs = await _context.logs.FindAsync(id);
            if (logs == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.funcionarios, "IdFuncionario", "Email", logs.FuncionarioId);
            return View(logs);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLogs,FuncionarioId,Data,HorasTrabalhadas")] Logs logs)
        {
            if (id != logs.IdLogs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogsExists(logs.IdLogs))
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
            ViewData["FuncionarioId"] = new SelectList(_context.funcionarios, "IdFuncionario", "Email", logs.FuncionarioId);
            return View(logs);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.logs == null)
            {
                return NotFound();
            }

            var logs = await _context.logs
                .Include(l => l.Funcionario)
                .FirstOrDefaultAsync(m => m.IdLogs == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.logs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.logs'  is null.");
            }
            var logs = await _context.logs.FindAsync(id);
            if (logs != null)
            {
                _context.logs.Remove(logs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogsExists(int id)
        {
          return (_context.logs?.Any(e => e.IdLogs == id)).GetValueOrDefault();
        }
    }
}
