using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTprm.Models;

namespace MvcTprm.Controllers
{
    public class TipoDeServicoController : Controller
    {
        private readonly MvcTprmContext _context;

        public TipoDeServicoController(MvcTprmContext context)
        {
            _context = context;
        }

        // GET: TipoDeServico
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeServicos.ToListAsync());
        }

        // GET: TipoDeServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServico = await _context.TipoDeServicos
                .FirstOrDefaultAsync(m => m.TipoDeServicoId == id);
            if (tipoDeServico == null)
            {
                return NotFound();
            }

            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServico = await _context.TipoDeServicos.FindAsync(id);
            if (tipoDeServico == null)
            {
                return NotFound();
            }
            return View(tipoDeServico);
        }

        // POST: TipoDeServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (id != tipoDeServico.TipoDeServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeServicoExists(tipoDeServico.TipoDeServicoId))
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
            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServico = await _context.TipoDeServicos
                .FirstOrDefaultAsync(m => m.TipoDeServicoId == id);
            if (tipoDeServico == null)
            {
                return NotFound();
            }

            return View(tipoDeServico);
        }

        // POST: TipoDeServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeServico = await _context.TipoDeServicos.FindAsync(id);
            _context.TipoDeServicos.Remove(tipoDeServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeServicoExists(int id)
        {
            return _context.TipoDeServicos.Any(e => e.TipoDeServicoId == id);
        }
    }
}
