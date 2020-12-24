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
    public class LinhaProdsController : Controller
    {
        private readonly IntervManutContext _context;

        public LinhaProdsController(IntervManutContext context)
        {
            _context = context;
        }

        // GET: LinhaProds
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhaProd.ToListAsync());
        }

        // GET: LinhaProds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProd = await _context.LinhaProd
                .FirstOrDefaultAsync(m => m.LinhaProdId == id);
            if (linhaProd == null)
            {
                return NotFound();
            }

            return View(linhaProd);
        }

        // GET: LinhaProds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinhaProds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinhaProdId,CodLinha,Descricao")] LinhaProd linhaProd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaProd);
        }

        // GET: LinhaProds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProd = await _context.LinhaProd.FindAsync(id);
            if (linhaProd == null)
            {
                return NotFound();
            }
            return View(linhaProd);
        }

        // POST: LinhaProds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinhaProdId,CodLinha,Descricao")] LinhaProd linhaProd)
        {
            if (id != linhaProd.LinhaProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaProdExists(linhaProd.LinhaProdId))
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
            return View(linhaProd);
        }

        // GET: LinhaProds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProd = await _context.LinhaProd
                .FirstOrDefaultAsync(m => m.LinhaProdId == id);
            if (linhaProd == null)
            {
                return NotFound();
            }

            return View(linhaProd);
        }

        // POST: LinhaProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaProd = await _context.LinhaProd.FindAsync(id);
            _context.LinhaProd.Remove(linhaProd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaProdExists(int id)
        {
            return _context.LinhaProd.Any(e => e.LinhaProdId == id);
        }
    }
}
