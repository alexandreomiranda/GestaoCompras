using GestaoCompras.Application.ViewModels;
using GestaoCompras.Domain.Entities;
using GestaoCompras.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestaoCompras.Controllers
{
    public class SolicitacaoComprasController : Controller
    {
        private GestaoComprasContext db = new GestaoComprasContext();

        public ActionResult Index()
        {
            return View(db.SolicitacaoCompras
                .Include(p => p.Produto)
                .ToList());
        }
        // GET: SolicitacaoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompras.Find(id);
            if (solicitacaoCompra == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto");
            ViewBag.DataAtual = DateTime.Today;
            return View();
        }

        // POST: SolicitacaoCompras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitacaoCompraId,DataSolicitacao,UsuarioSolicitante,DeptoSolicitante,Quantidade,DataLimiteRecebimento,StatusSolicitacao,ProdutoId")] SolicitacaoCompra solicitacaoCompra)
        {
            if (ModelState.IsValid)
            {
                db.SolicitacaoCompras.Add(solicitacaoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompras.Find(id);
            if (solicitacaoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // POST: SolicitacaoCompras/Edit/5
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
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", solicitacaoCompra.ProdutoId);
            return View(solicitacaoCompra);
        }

        // GET: SolicitacaoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompras.Find(id);
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
            SolicitacaoCompra solicitacaoCompra = db.SolicitacaoCompras.Find(id);
            db.SolicitacaoCompras.Remove(solicitacaoCompra);
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