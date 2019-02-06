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
    [Authorize(Roles = "Administrador")]
    public class DividaController : Controller
    {
        private TprmContext db = new TprmContext();

        // GET: Divida
        public ActionResult Index()
        {
            var dividas = db.Dividas.Include(d => d.Cliente);
            return View(dividas.ToList());
        }

        // GET: Divida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divida divida = db.Dividas.Find(id);
            if (divida == null)
            {
                return HttpNotFound();
            }
            return View(divida);
        }

        // GET: Divida/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            return View();
        }

        // POST: Divida/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DividaId,ClienteId,ValorDaDivida")] Divida divida)
        {
            if (ModelState.IsValid)
            {
                db.Dividas.Add(divida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", divida.ClienteId);
            return View(divida);
        }

        // GET: Divida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divida divida = db.Dividas.Find(id);
            if (divida == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", divida.ClienteId);
            return View(divida);
        }

        // POST: Divida/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DividaId,ClienteId,ValorDaDivida")] Divida divida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(divida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", divida.ClienteId);
            return View(divida);
        }

        // GET: Divida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divida divida = db.Dividas.Find(id);
            if (divida == null)
            {
                return HttpNotFound();
            }
            return View(divida);
        }

        // POST: Divida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Divida divida = db.Dividas.Find(id);
            db.Dividas.Remove(divida);
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
