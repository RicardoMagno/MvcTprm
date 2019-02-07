using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTprm.DAL;
using MvcTprm.Models;
using System.Data.Entity;
using System.Net;
using PagedList;

namespace MvcTprm.Controllers
{
    public class AdministradorController : Controller
    {
        private TprmContext db = new TprmContext();

        // GET: Administrador/Divida/IndexDivida
        public ActionResult IndexDivida(string sortOrder, string currentFilter, string searchString, int? page)
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

            var dividas = from s in db.Dividas.Include(d => d.Cliente)
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                dividas = dividas.Where(s => s.Cliente.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    dividas = dividas.OrderByDescending(s => s.Cliente.Nome
                    );
                    break;
                default:
                    dividas = dividas.OrderBy(s => s.Cliente.Nome);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(dividas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Administrador/Divida/CreateDivida
        public ActionResult CreateDivida()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            return View();
        }

        // POST: Administrador/Divida/CreateDivida
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDivida([Bind(Include = "DividaId,ClienteId,ValorDaDivida")] Divida divida)
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

        // GET: Administrador/Divida/DeleteDivida/5
        public ActionResult DeleteDivida(int? id)
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

        // POST: Administrador/Divida/DeleteDivida/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedDivida(int id)
        {
            Divida divida = db.Dividas.Find(id);
            db.Dividas.Remove(divida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Administrador/TipoDeServico/IndexTipoDeServido
        public ActionResult IndexTipoDeServico(string sortOrder, string currentFilter, string searchString, int? page)        {
            
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

        // GET: Administrador/TipoDeServico/CreateTipoDeServico
        public ActionResult CreateTipoDeServico()
        {
            return View();
        }

        // POST: Administrador/TipoDeServico/CreateTipoDeServico
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTipoDeServico([Bind(Include = "TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeServicos.Add(tipoDeServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeServico);
        }

        // GET: Administrador/TipoDeServico/EditTipoDeServico/5
        public ActionResult EditTipoDeServico(int? id)
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

        // POST: Administrador/TipoDeServico/EditTipoDeServico/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTipoDeServico([Bind(Include = "TipoDeServicoId,NomeServico,Valor,Descricao")] TipoDeServico tipoDeServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeServico);
        }

        // GET: Administrador/TipoDeServico/DeleteTipoDeServico/5
        public ActionResult DeleteTipoDeServico(int? id)
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

        // POST: Administrador/TipoDeServico/DeleteTipoDeServico/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTipoDeServico(int id)
        {
            TipoDeServico tipoDeServico = db.TipoDeServicos.Find(id);
            db.TipoDeServicos.Remove(tipoDeServico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Administrador/Cliente/IndexCliente
        public ViewResult IndexCliente(string sortOrder, string currentFilter, string searchString, int? page)
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

            var clientes = from s in db.Clientes
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(s => s.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clientes = clientes.OrderByDescending(s => s.Nome
                    );
                    break;
                default:
                    clientes = clientes.OrderBy(s => s.Nome);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(clientes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Administrador/Cliente/CreateCliente
        public ActionResult CreateCliente()
        {
            return View();
        }

        // POST: Administrador/Cliente/CreateCliente
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente([Bind(Include = "ClienteId,Nome")] Cliente cliente, Divida divida)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Administrador/Cliente/EditCliente/5
        public ActionResult EditCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Administrador/Cliente/EditCliente/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente([Bind(Include = "ClienteId,Nome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Administrador/Cliente/DeleteCliente/5
        public ActionResult DeleteCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Administrador/Cliente/Delete/Cliente/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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