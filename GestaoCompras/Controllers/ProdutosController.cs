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
    public class ProdutosController : Controller
    {
        private GestaoComprasContext db = new GestaoComprasContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produto = db.Produtos.Include(p => p.ClasseProduto).Include(p => p.Unidade);
            return View(produto.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClasseProdutoId = new SelectList(db.ClasseProdutos, "ClasseProdutoId", "NomeClasse");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "NomeUnidade");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseProdutoId = new SelectList(db.ClasseProdutos, "ClasseProdutoId", "NomeClasse", produto.ClasseProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "NomeUnidade", produto.UnidadeId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseProdutoId = new SelectList(db.ClasseProdutos, "ClasseProdutoId", "NomeClasse", produto.ClasseProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "NomeUnidade", produto.UnidadeId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseProdutoId = new SelectList(db.ClasseProdutos, "ClasseProdutoId", "NomeClasse", produto.ClasseProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "NomeUnidade", produto.UnidadeId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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