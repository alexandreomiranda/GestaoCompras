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
    public class ClasseProdutosController : Controller
    {
        private GestaoComprasContext db = new GestaoComprasContext();

        public ActionResult Index()
        {
            return View(db.ClasseProdutos.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasseProduto classeProduto = db.ClasseProdutos.Find(id);
            if (classeProduto == null)
            {
                return HttpNotFound();
            }
            return View(classeProduto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClasseProduto classeProduto)
        {
            if (ModelState.IsValid)
            {
                db.ClasseProdutos.Add(classeProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classeProduto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasseProduto classeProduto = db.ClasseProdutos.Find(id);
            if (classeProduto == null)
            {
                return HttpNotFound();
            }
            return View(classeProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClasseProduto classeProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classeProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classeProduto);
        }

        public ActionResult Delete(int id)
        {
            ClasseProduto classeProduto = db.ClasseProdutos.Find(id);
            return View(classeProduto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClasseProduto classeProduto = db.ClasseProdutos.Find(id);
            db.ClasseProdutos.Remove(classeProduto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}