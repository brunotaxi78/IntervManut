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
    public class TecnicosIntervencoesController : Controller
    {
        private readonly IntervManutContext _context;

        public TecnicosIntervencoesController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: TecnicosIntervencoes
        public async Task<IActionResult> Index()
        {
            var intervManutContext = _context.TecnicoIntervencao.Include(t => t.Intervencao).Include(t => t.Tecnico);
            return View(await intervManutContext.ToListAsync());
        }

        // GET: TecnicosIntervencoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicoIntervencao = await _context.TecnicoIntervencao
                .Include(t => t.Intervencao)
                .Include(t => t.Tecnico)
                .FirstOrDefaultAsync(m => m.TecnicoIntervencaoId == id);
            if (tecnicoIntervencao == null)
            {
                return NotFound();
            }

            return View(tecnicoIntervencao);
        }

        // GET: TecnicosIntervencoes/Create
        public IActionResult Create()
        {
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao");
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome");
            return View();
        }

        // POST: TecnicosIntervencoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TecnicoIntervencaoId,TecnicoId,IntervencaoId")] TecnicoIntervencao tecnicoIntervencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicoIntervencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", tecnicoIntervencao.IntervencaoId);
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome", tecnicoIntervencao.TecnicoId);
            return View(tecnicoIntervencao);
        }

        // GET: TecnicosIntervencoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicoIntervencao = await _context.TecnicoIntervencao.FindAsync(id);
            if (tecnicoIntervencao == null)
            {
                return NotFound();
            }
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", tecnicoIntervencao.IntervencaoId);
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome", tecnicoIntervencao.TecnicoId);
            return View(tecnicoIntervencao);
        }

        // POST: TecnicosIntervencoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TecnicoIntervencaoId,TecnicoId,IntervencaoId")] TecnicoIntervencao tecnicoIntervencao)
        {
            if (id != tecnicoIntervencao.TecnicoIntervencaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicoIntervencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoIntervencaoExists(tecnicoIntervencao.TecnicoIntervencaoId))
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
            ViewData["IntervencaoId"] = new SelectList(_context.Intervencao, "IntervencaoId", "Descricao", tecnicoIntervencao.IntervencaoId);
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome", tecnicoIntervencao.TecnicoId);
            return View(tecnicoIntervencao);
        }

        // GET: TecnicosIntervencoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicoIntervencao = await _context.TecnicoIntervencao
                .Include(t => t.Intervencao)
                .Include(t => t.Tecnico)
                .FirstOrDefaultAsync(m => m.TecnicoIntervencaoId == id);
            if (tecnicoIntervencao == null)
            {
                return NotFound();
            }

            return View(tecnicoIntervencao);
        }

        // POST: TecnicosIntervencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnicoIntervencao = await _context.TecnicoIntervencao.FindAsync(id);
            _context.TecnicoIntervencao.Remove(tecnicoIntervencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoIntervencaoExists(int id)
        {
            return _context.TecnicoIntervencao.Any(e => e.TecnicoIntervencaoId == id);
        }
    }
}
