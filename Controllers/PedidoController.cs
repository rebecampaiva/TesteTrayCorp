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
    public class PedidoController : Controller
    {
        private readonly DB_TesteContext _context;

        public PedidoController(DB_TesteContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Lanche/Create
        public IActionResult Create()
        {

            ViewData["LancheId"] = new SelectList((from s in _context.Lanches.OrderBy(m => m.Nome).ToList()
                                                      select new
                                                      {
                                                          LancheId = s.LancheId,
                                                          LancheNome = s.LancheId + " - " + s.Nome
                                                      }), "LancheId", "LancheNome", null);

            var ultimoReg = _context.Pedidos.Take(1).Single();

            ViewData["NumPedido"] = ultimoReg.PedidoId + 1;


            return View();
        }

        [HttpPost]
        public float BuscaLanche(int lancheid)
        {

            float valor = Convert.ToInt32(_context.Lanches.Single(r => r.LancheId == lancheid).ValorBase);

            

            return valor;
        }


        [HttpPost]
        public double BuscaLancheCombo(int lancheid)
        {

            double valor = Convert.ToDouble(_context.Lanches.Single(r => r.LancheId == lancheid).ValorBase);

            double valorcombo = 5.90 + valor;

            return valorcombo;
        }

        [HttpPost]
        public double CalculaValorLanche(int lancheid, int qtde, bool combo)
        {
            double valorcombo = 0;
            double valor = Convert.ToDouble(_context.Lanches.Single(r => r.LancheId == lancheid).ValorBase);
            if (qtde == 1)
            {
                if (combo == true)
                {
                    valorcombo = 5.90 + (valor * qtde);
                    valor = valorcombo;
                }

                else
                {
                    valorcombo = valor * qtde;
                    valor = valorcombo;
                }
            }
            else if (qtde == 2)
            {

                if (combo == true)
                {
                    valorcombo = 5.90 + (valor * qtde);
                    valor = valorcombo;
                }

                else
                {
                    valorcombo = valor * qtde;
                    valor = valorcombo;
                }

                valor = valor * 0.97;


            }

            else if (qtde == 3)
            {

                if (combo == true)
                {
                    valorcombo = 5.90 + (valor * qtde);
                    valor = valorcombo;
                }

                else
                {
                    valorcombo = valor * qtde;
                    valor = valorcombo;
                }

                valor = valor * 0.95;


            }

            else if (qtde >= 5)
            {

                if (combo == true)
                {
                    valorcombo = 5.90 + (valor * qtde);
                    valor = valorcombo;
                }

                else
                {
                    valorcombo = valor * qtde;
                    valor = valorcombo;
                }

                valor = valor * 0.9;


            }
            return valor;
        }


        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,LancheId,Combo")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Status = 1;

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId, LancheId,Combo")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    pedido.Status = 2;
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!IngredienteExists(pedido.PedidoId))
                    //{
                        return NotFound();
                    //}
                    //else
                    //{
                      //  throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
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
