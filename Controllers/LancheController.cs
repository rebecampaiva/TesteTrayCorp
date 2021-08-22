using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MRO.Data;
using MRO.Models;

namespace MRO.Controllers
{
    public class LancheController : Controller
    {
        private readonly DB_TesteContext _context;

        public LancheController(DB_TesteContext context)
        {
            _context = context;
        }

        // GET: Unidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lanches.ToListAsync());
        }

        // GET: Lanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches
                .FirstOrDefaultAsync(m => m.LancheId == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // GET: Lanche/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LancheId,Nome,Ativo,ImagemCaminho,ValorBase")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {

                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lanche);
        }

        // GET: Lanche/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            return View(lanche);
        }

        // POST: Lanche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LancheId,Nome,Ativo,ImagemCaminho,ValorBase")] Lanche lanche)
        {
            if (id != lanche.LancheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheExists(lanche.LancheId))
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
            return View(lanche);
        }

        // GET: Unidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches
                .FirstOrDefaultAsync(m => m.LancheId == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // POST: Lanche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lanche = await _context.Lanches.FindAsync(id);
            _context.Lanches.Remove(lanche);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheExists(int id)
        {
            var nome = _context.Lanches.Single(r=> r.LancheId == id).Nome;

            var lanche = _context.Lanches.Any(e => e.Nome == nome);

            return _context.Lanches.Any(e => e.LancheId == id);
        }
    }
}
