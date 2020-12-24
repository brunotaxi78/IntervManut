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
    public class TiposTecnicosController : Controller
    {
        private readonly IntervManutContext _context;

        public TiposTecnicosController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: TiposTecnicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTec.ToListAsync());
        }

        // GET: TiposTecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTec = await _context.TipoTec
                .FirstOrDefaultAsync(m => m.TipoTecId == id);
            if (tipoTec == null)
            {
                return NotFound();
            }

            return View(tipoTec);
        }

        // GET: TiposTecnicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposTecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoTecId,Tipo")] TipoTec tipoTec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTec);
        }

        // GET: TiposTecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTec = await _context.TipoTec.FindAsync(id);
            if (tipoTec == null)
            {
                return NotFound();
            }
            return View(tipoTec);
        }

        // POST: TiposTecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoTecId,Tipo")] TipoTec tipoTec)
        {
            if (id != tipoTec.TipoTecId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTecExists(tipoTec.TipoTecId))
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
            return View(tipoTec);
        }

        // GET: TiposTecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTec = await _context.TipoTec
                .FirstOrDefaultAsync(m => m.TipoTecId == id);
            if (tipoTec == null)
            {
                return NotFound();
            }

            return View(tipoTec);
        }

        // POST: TiposTecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTec = await _context.TipoTec.FindAsync(id);
            _context.TipoTec.Remove(tipoTec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTecExists(int id)
        {
            return _context.TipoTec.Any(e => e.TipoTecId == id);
        }
    }
}
