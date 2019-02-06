using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTprm.DAL;
using MvcTprm.Models;

namespace MvcTprm.Controllers
{
    public class TipoDeServicoController : Controller
    {
        private TprmContext db = new TprmContext();

        // GET: TipoDeServico
        public ActionResult Index()
        {
            return View(db.TipoDeServicos.ToList());
        }

        // GET: TipoDeServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServico tipoDeServico = db.TipoDeServicos.Find(id);
            if (tipoDeServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeServicos.Add(tipoDeServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServico tipoDeServico = db.TipoDeServicos.Find(id);
            if (tipoDeServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeServico);
        }

        // POST: TipoDeServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeServico);
        }

        // GET: TipoDeServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServico tipoDeServico = db.TipoDeServicos.Find(id);
            if (tipoDeServico == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeServico);
        }

        // POST: TipoDeServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeServico tipoDeServico = db.TipoDeServicos.Find(id);
            db.TipoDeServicos.Remove(tipoDeServico);
            db.SaveChanges();
            return RedirectToAction("Index");
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
