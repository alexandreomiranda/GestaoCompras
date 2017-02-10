using GestaoCompras.Domain.Entities;
using GestaoCompras.Domain.Interfaces.Repository;
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
    public class UnidadesController : Controller
    {
        /*        
        private readonly IRepository<Unidade> _repository;
        public UnidadesController(IRepository<Unidade> repo)
        {
            _repository = repo;
        }

        // GET: Unidades
        public ActionResult Index()
        {
            return View(_repository.ObterTodos());
        }
        */
        private GestaoComprasContext db = new GestaoComprasContext();

        public ActionResult Index()
        {
            return View(db.Unidades.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                db.Unidades.Add(unidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidade);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidade);
        }

        public ActionResult Delete(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            return View(unidade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            db.Unidades.Remove(unidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}