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
    public class TecnicosController : Controller
    {
        private readonly IntervManutContext _context;

        public TecnicosController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: Tecnicos
        public async Task<IActionResult> Index()
        {
            var intervManutContext = _context.Tecnico.Include(t => t.TipoTec);
            return View(await intervManutContext.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnico
                .Include(t => t.TipoTec)
                .FirstOrDefaultAsync(m => m.TecnicoId == id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // GET: Tecnicos/Create
        public IActionResult Create()
        {
            ViewData["TipoTecId"] = new SelectList(_context.Set<TipoTec>(), "TipoTecId", "TipoTecId");
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TecnicoId,Nome,Empresa,TipoTecId")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoTecId"] = new SelectList(_context.Set<TipoTec>(), "TipoTecId", "TipoTecId", tecnico.TipoTecId);
            return View(tecnico);
        }

        // GET: Tecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnico.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }
            ViewData["TipoTecId"] = new SelectList(_context.Set<TipoTec>(), "TipoTecId", "TipoTecId", tecnico.TipoTecId);
            return View(tecnico);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TecnicoId,Nome,Empresa,TipoTecId")] Tecnico tecnico)
        {
            if (id != tecnico.TecnicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoExists(tecnico.TecnicoId))
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
            ViewData["TipoTecId"] = new SelectList(_context.Set<TipoTec>(), "TipoTecId", "TipoTecId", tecnico.TipoTecId);
            return View(tecnico);
        }

        // GET: Tecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnico
                .Include(t => t.TipoTec)
                .FirstOrDefaultAsync(m => m.TecnicoId == id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnico = await _context.Tecnico.FindAsync(id);
            _context.Tecnico.Remove(tecnico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnico.Any(e => e.TecnicoId == id);
        }
    }
}
