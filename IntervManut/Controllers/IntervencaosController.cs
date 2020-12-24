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
    public class IntervencaosController : Controller
    {
        private readonly IntervManutContext _context;

        public IntervencaosController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: Intervencaos
        public async Task<IActionResult> Index()
        {
            var intervManutContext = _context.Intervencao.Include(i => i.Equipamento).Include(i => i.Estado).Include(i => i.Tecnico).Include(i => i.TipoIntervencao);
            return View(await intervManutContext.ToListAsync());
        }

        // GET: Intervencaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencao = await _context.Intervencao
                .Include(i => i.Equipamento)
                .Include(i => i.Estado)
                .Include(i => i.Tecnico)
                .Include(i => i.TipoIntervencao)
                .FirstOrDefaultAsync(m => m.IntervencaoId == id);
            if (intervencao == null)
            {
                return NotFound();
            }

            return View(intervencao);
        }

        // GET: Intervencaos/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "CodEquipamento");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Descricao");
            ViewData["TecnicoId"] = new SelectList(_context.Set<Tecnico>(), "TecnicoId", "Nome");
            ViewData["TipoIntevencaoId"] = new SelectList(_context.Set<TipoIntervencao>(), "TipoIntervencaoId", "Nome");
            return View();
        }

        // POST: Intervencaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntervencaoId,Descricao,EquipamentoId,TecnicoId,DataCriacao,DataFim,EstadoId,TipoIntevencaoId,ResumoTrabalho")] Intervencao intervencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intervencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "CodEquipamento", intervencao.EquipamentoId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Descricao", intervencao.EstadoId);
            ViewData["TecnicoId"] = new SelectList(_context.Set<Tecnico>(), "TecnicoId", "Nome", intervencao.TecnicoId);
            ViewData["TipoIntevencaoId"] = new SelectList(_context.Set<TipoIntervencao>(), "TipoIntervencaoId", "Nome", intervencao.TipoIntevencaoId);
            return View(intervencao);
        }

        // GET: Intervencaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencao = await _context.Intervencao.FindAsync(id);
            if (intervencao == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "CodEquipamento", intervencao.EquipamentoId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Descricao", intervencao.EstadoId);
            ViewData["TecnicoId"] = new SelectList(_context.Set<Tecnico>(), "TecnicoId", "Nome", intervencao.TecnicoId);
            ViewData["TipoIntevencaoId"] = new SelectList(_context.Set<TipoIntervencao>(), "TipoIntervencaoId", "Nome", intervencao.TipoIntevencaoId);
            return View(intervencao);
        }

        // POST: Intervencaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntervencaoId,Descricao,EquipamentoId,TecnicoId,DataCriacao,DataFim,EstadoId,TipoIntevencaoId,ResumoTrabalho")] Intervencao intervencao)
        {
            if (id != intervencao.IntervencaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntervencaoExists(intervencao.IntervencaoId))
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
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "CodEquipamento", intervencao.EquipamentoId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Descricao", intervencao.EstadoId);
            ViewData["TecnicoId"] = new SelectList(_context.Set<Tecnico>(), "TecnicoId", "Nome", intervencao.TecnicoId);
            ViewData["TipoIntevencaoId"] = new SelectList(_context.Set<TipoIntervencao>(), "TipoIntervencaoId", "Nome", intervencao.TipoIntevencaoId);
            return View(intervencao);
        }

        // GET: Intervencaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervencao = await _context.Intervencao
                .Include(i => i.Equipamento)
                .Include(i => i.Estado)
                .Include(i => i.Tecnico)
                .Include(i => i.TipoIntervencao)
                .FirstOrDefaultAsync(m => m.IntervencaoId == id);
            if (intervencao == null)
            {
                return NotFound();
            }

            return View(intervencao);
        }

        // POST: Intervencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intervencao = await _context.Intervencao.FindAsync(id);
            _context.Intervencao.Remove(intervencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntervencaoExists(int id)
        {
            return _context.Intervencao.Any(e => e.IntervencaoId == id);
        }
    }
}
