using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTprm.Data;
using MvcTprm.Models;

namespace MvcTprm.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly MvcTprmContext _context;

        public TransacaoController(MvcTprmContext context)
        {
            _context = context;
        }

        // GET: Transacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transacoes.ToListAsync());
        }

        // GET: Transacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.TransacaoId == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransacaoId,OwnerID,NomeEmpresa,NomeEmpresaContratada,tipoDeServico,valorDoServico,descricao,StatusTransacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            return View(transacao);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransacaoId,OwnerID,NomeEmpresa,NomeEmpresaContratada,tipoDeServico,valorDoServico,descricao,StatusTransacao")] Transacao transacao)
        {
            if (id != transacao.TransacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.TransacaoId))
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
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.TransacaoId == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
            return _context.Transacoes.Any(e => e.TransacaoId == id);
        }
    }
}
