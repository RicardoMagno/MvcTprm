using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTprm.Models;
using MvcTprm.Data;

namespace MvcTprm.Controllers
{
    public class DividaController : Controller
    {
        private readonly MvcTprmContext _context;

        public DividaController(MvcTprmContext context)
        {
            _context = context;
        }

        // GET: Divida
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dividas.ToListAsync());
        }

        // GET: Divida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divida = await _context.Dividas
                .FirstOrDefaultAsync(m => m.DividaId == id);
            if (divida == null)
            {
                return NotFound();
            }

            return View(divida);
        }

        // GET: Divida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DividaId,ClienteId,ClienteNome,ValorDaDivida")] Divida divida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divida);
        }

        // GET: Divida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divida = await _context.Dividas.FindAsync(id);
            if (divida == null)
            {
                return NotFound();
            }
            return View(divida);
        }

        // POST: Divida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DividaId,ClienteId,ClienteNome,ValorDaDivida")] Divida divida)
        {
            if (id != divida.DividaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DividaExists(divida.DividaId))
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
            return View(divida);
        }

        // GET: Divida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divida = await _context.Dividas
                .FirstOrDefaultAsync(m => m.DividaId == id);
            if (divida == null)
            {
                return NotFound();
            }

            return View(divida);
        }

        // POST: Divida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divida = await _context.Dividas.FindAsync(id);
            _context.Dividas.Remove(divida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DividaExists(int id)
        {
            return _context.Dividas.Any(e => e.DividaId == id);
        }
    }
}
