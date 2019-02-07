using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTprm.DAL;
using System.Data;
using System.Net;
using MvcTprm.Models;
using PagedList;


namespace MvcTprm.Controllers
{
    public class AnalistaController : Controller
    {

        private TprmContext db = new TprmContext();

        // GET: Analista/TipoDeServico/IndexTipoDeServico
        public ActionResult IndexTipoDeServico(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tipos = from s in db.TipoDeServicos
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tipos = tipos.Where(s => s.NomeServico.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tipos = tipos.OrderByDescending(s => s.NomeServico
                    );
                    break;
                default:
                    tipos = tipos.OrderBy(s => s.NomeServico);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tipos.ToPagedList(pageNumber, pageSize));

        }
        // GET: Analista/Transacao/IndexTransacao
        public ActionResult IndexTransacao(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var transacoes = from s in db.Transacoes
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                transacoes = transacoes.Where(s => s.empresaContratada.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    transacoes = transacoes.OrderByDescending(s => s.empresaContratada.Nome);
                    break;
                default:
                    transacoes = transacoes.OrderBy(s => s.empresaContratada.Nome);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(transacoes.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Analista/Transacao/EditTransacao/5
        public ActionResult EditTransacao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            if (!(transacao.StatusTransacao == Status.Submetida))
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Analista/Transacao/EditTransacao/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transacaoToUpdate = db.Transacoes.Find(id);
            if (!(transacaoToUpdate.StatusTransacao == Status.Submetida))
            {
                return RedirectToAction("Index");
            }
            else if (TryUpdateModel(transacaoToUpdate, "",
               new string[] { "empresaContratanteID", "enpresaContratadaID", "tipoDeServico", "valorDoServico", "descricao", "StatusTransacao" }))
                {
                    try
                    {
                    if (!(transacaoToUpdate.StatusTransacao == Status.Submetida))
                    {
                        var divida = db.Dividas.Find(transacaoToUpdate.empresaContratadaID);
                        divida.ValorDaDivida = +5;
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                    }
                    catch (DataException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
            return View(transacaoToUpdate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}