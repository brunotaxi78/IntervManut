using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntervManut.Data;
using IntervManut.Models;

namespace IntervManut.Controllers
{
    public class PecasController : Controller
    {
        private readonly IntervManutContext _context;

        public PecasController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: Pecas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peca.ToListAsync());
        }

        // GET: Pecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Peca
                .FirstOrDefaultAsync(m => m.PecaId == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // GET: Pecas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PecaId,CodPeca,Descricao,Quantidade")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peca);
        }

        // GET: Pecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Peca.FindAsync(id);
            if (peca == null)
            {
                return NotFound();
            }
            return View(peca);
        }

        // POST: Pecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PecaId,CodPeca,Descricao,Quantidade")] Peca peca)
        {
            if (id != peca.PecaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecaExists(peca.PecaId))
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
            return View(peca);
        }

        // GET: Pecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Peca
                .FirstOrDefaultAsync(m => m.PecaId == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // POST: Pecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peca = await _context.Peca.FindAsync(id);
            _context.Peca.Remove(peca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecaExists(int id)
        {
            return _context.Peca.Any(e => e.PecaId == id);
        }
    }
}
