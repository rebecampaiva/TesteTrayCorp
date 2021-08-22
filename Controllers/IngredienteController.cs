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
    public class IngredienteController : Controller
    {
        private readonly DB_TesteContext _context;

        public IngredienteController(DB_TesteContext context)
        {
            _context = context;
        }

        // GET: Unidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredientes.ToListAsync());
        }

        // GET: Lanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(m => m.IngredienteId == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
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
        public async Task<IActionResult> Create([Bind("IngredienteId,Nome,Ativo,Valor")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                ingrediente.DataIncAlt = DateTime.Now;

                _context.Add(ingrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingrediente);
        }

        // GET: Ingrediente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingrediente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredienteId,Nome,Ativo,Valor")] Ingrediente ingrediente)
        {
            if (id != ingrediente.IngredienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    ingrediente.DataIncAlt = DateTime.Now;
                    _context.Update(ingrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteExists(ingrediente.IngredienteId))
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
            return View(ingrediente);
        }

        // GET: Unidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(m => m.IngredienteId == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: Ingrediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteExists(int id)
        {
            var nome = _context.Ingredientes.Single(r=> r.IngredienteId == id).Nome;

            var ingrediente = _context.Ingredientes.Any(e => e.Nome == nome);

            return _context.Ingredientes.Any(e => e.IngredienteId == id);
        }
    }
}
