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
    public class TiposIntervencoesController : Controller
    {
        private readonly IntervManutContext _context;

        public TiposIntervencoesController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: TiposIntervencoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIntervencao.ToListAsync());
        }

        // GET: TiposIntervencoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIntervencao = await _context.TipoIntervencao
                .FirstOrDefaultAsync(m => m.TipoIntervencaoId == id);
            if (tipoIntervencao == null)
            {
                return NotFound();
            }

            return View(tipoIntervencao);
        }

        // GET: TiposIntervencoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposIntervencoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoIntervencaoId,Nome")] TipoIntervencao tipoIntervencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIntervencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIntervencao);
        }

        // GET: TiposIntervencoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIntervencao = await _context.TipoIntervencao.FindAsync(id);
            if (tipoIntervencao == null)
            {
                return NotFound();
            }
            return View(tipoIntervencao);
        }

        // POST: TiposIntervencoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoIntervencaoId,Nome")] TipoIntervencao tipoIntervencao)
        {
            if (id != tipoIntervencao.TipoIntervencaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIntervencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIntervencaoExists(tipoIntervencao.TipoIntervencaoId))
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
            return View(tipoIntervencao);
        }

        // GET: TiposIntervencoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIntervencao = await _context.TipoIntervencao
                .FirstOrDefaultAsync(m => m.TipoIntervencaoId == id);
            if (tipoIntervencao == null)
            {
                return NotFound();
            }

            return View(tipoIntervencao);
        }

        // POST: TiposIntervencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoIntervencao = await _context.TipoIntervencao.FindAsync(id);
            _context.TipoIntervencao.Remove(tipoIntervencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIntervencaoExists(int id)
        {
            return _context.TipoIntervencao.Any(e => e.TipoIntervencaoId == id);
        }
    }
}
