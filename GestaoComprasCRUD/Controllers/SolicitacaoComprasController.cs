using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestaoComprasCRUD.Models;

namespace GestaoComprasCRUD.Controllers
{
    public class SolicitacaoComprasController : Controller
    {
        private CRUDContext db = new CRUDContext();

        // GET: SolicitacaoCompras
        public ActionResult Index()
        {
            var solicitacaoCompra = db.SolicitacaoCompra.Include(s => s.Produto);
            return View(solicitacaoCompra.ToList());
        }

        // GET: SolicitacaoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompra.Find(id);
            if (solicitacaoCompra == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "NomeProduto");
            return View();
        }

        // POST: SolicitacaoCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitacaoCompraId,DataSolicitacao,UsuarioSolicitante,DeptoSolicitante,Quantidade,DataLimiteRecebimento,StatusSolicitacao,ProdutoId")] SolicitacaoCompra solicitacaoCompra)
        {
            if (ModelState.IsValid)
            {
                db.SolicitacaoCompra.Add(solicitacaoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompra.Find(id);
            if (solicitacaoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // POST: SolicitacaoCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolicitacaoCompraId,DataSolicitacao,UsuarioSolicitante,DeptoSolicitante,Quantidade,DataLimiteRecebimento,StatusSolicitacao,ProdutoId")] SolicitacaoCompra solicitacaoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacaoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompra.Find(id);
            if (solicitacaoCompra == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoCompra);
        }

        // POST: SolicitacaoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompra.Find(id);
            db.SolicitacaoCompra.Remove(solicitacaoCompra);
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
