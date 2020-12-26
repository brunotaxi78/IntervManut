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
    public class IntervencaoPecasController : Controller
    {
        private readonly IntervManutContext _context;

        public IntervencaoPecasController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: IntervencaoPecas
        public async Task<IActionResult> Index()
        {
            var intervManutContext = _context.IntervencaoPeca.Include(i => i.Intervencao).Include(i => i.Peca);
            return View(await intervManutContext.ToListAsync());
        }

        // GET: IntervencaoPecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencaoPeca = await _context.IntervencaoPeca
                .Include(i => i.Intervencao)
                .Include(i => i.Peca)
                .FirstOrDefaultAsync(m => m.IntervencaoPecaId == id);
            if (intervencaoPeca == null)
            {
                return NotFound();
            }

            return View(intervencaoPeca);
        }

        // GET: IntervencaoPecas/Create
        public IActionResult Create()
        {
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao");
            ViewData["PecaId"] = new SelectList(_context.Peca, "PecaId", "Descricao");
            return View();
        }

        // POST: IntervencaoPecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntervencaoPecaId,IntervencaoId,PecaId")] IntervencaoPeca intervencaoPeca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intervencaoPeca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", intervencaoPeca.IntervencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "PecaId", "Descricao", intervencaoPeca.PecaId);
            return View(intervencaoPeca);
        }

        // GET: IntervencaoPecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencaoPeca = await _context.IntervencaoPeca.FindAsync(id);
            if (intervencaoPeca == null)
            {
                return NotFound();
            }
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", intervencaoPeca.IntervencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "PecaId", "Descricao", intervencaoPeca.PecaId);
            return View(intervencaoPeca);
        }

        // POST: IntervencaoPecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntervencaoPecaId,IntervencaoId,PecaId")] IntervencaoPeca intervencaoPeca)
        {
            if (id != intervencaoPeca.IntervencaoPecaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervencaoPeca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntervencaoPecaExists(intervencaoPeca.IntervencaoPecaId))
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
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", intervencaoPeca.IntervencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "PecaId", "Descricao", intervencaoPeca.PecaId);
            return View(intervencaoPeca);
        }

        // GET: IntervencaoPecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencaoPeca = await _context.IntervencaoPeca
                .Include(i => i.Intervencao)
                .Include(i => i.Peca)
                .FirstOrDefaultAsync(m => m.IntervencaoPecaId == id);
            if (intervencaoPeca == null)
            {
                return NotFound();
            }

            return View(intervencaoPeca);
        }

        // POST: IntervencaoPecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intervencaoPeca = await _context.IntervencaoPeca.FindAsync(id);
            _context.IntervencaoPeca.Remove(intervencaoPeca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntervencaoPecaExists(int id)
        {
            return _context.IntervencaoPeca.Any(e => e.IntervencaoPecaId == id);
        }
    }
}
