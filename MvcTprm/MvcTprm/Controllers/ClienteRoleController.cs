using System.Linq;
using System.Web.Mvc;
using MvcTprm.DAL;
using MvcTprm.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using PagedList;
using System;



namespace MvcTprm.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClienteRoleController : Controller
    {
        private TprmContext db = new TprmContext();

        // GET: ClienteRole/Transacao/IndexTransacao
        public ActionResult IndexTransacao()
        {
            return View(db.Transacoes.ToList());
        }

        // GET: ClienteRole/Transacao/DetailsTransacao/5
        public ActionResult DetailsTransacao(int? id)
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
            return View(transacao);
        }
        // GET: ClienteRole/Transacao/CreateTransacao
        public ActionResult CreateTransacao()
        {
            return View();
        }

        // POST: ClienteRole/Transacao/CreateTransacao
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransacao([Bind(Include = "TransacaoId,empresaContratanteID,enpresaContratadaID,tipoDeServico,valorDoServico,descricao,StatusTransacao")] Transacao transacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Transacoes.Add(transacao);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Incapaz de Salvar, Tente novamente.");
            }

            return View(transacao);
        }

        // GET: ClienteRole/Transacao/EditTransacao/5
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
            return View(transacao);
        }

        // POST: ClienteRole/Transacao/EditTransacao/5
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
            if (TryUpdateModel(transacaoToUpdate, "",
               new string[] { "empresaContratanteID", "enpresaContratadaID", "tipoDeServico", "valorDoServico", "descricao", "StatusTransacao" }))
            {
                try
                {
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

        // GET: ClienteRole/Transacao/Delete/5
        public ActionResult DeleteTransacao(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: ClienteRole/Transacao/DeleteTransacao/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Transacao transacaoToDelete = new Transacao() { TransacaoId = id };
                db.Entry(transacaoToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                return RedirectToAction("Delete", new { id = id, saveChanges = true });
            }
            return RedirectToAction("Index");
        }
    }
}