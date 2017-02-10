using GestaoCompras.Application.Interfaces;
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
    public class FornecedoresController : Controller
    {
        /*
        private readonly IFornecedorAppService _fornecAppService;

        public FornecedoresController(IFornecedorAppService fornecAppService)
        {
            _fornecAppService = fornecAppService;
        }

        public ActionResult Index()
        {
            return View(_fornecAppService.ObterTodos());
        }

        */
        private GestaoComprasContext db = new GestaoComprasContext();

        public ActionResult Index()
        {
            return View(db.Fornecedores.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorContatoViewModel fcViewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = new Fornecedor()
                {
                    NomeFornecedor = fcViewModel.NomeFornecedor,
                    NomeFantasiaFornecedor = fcViewModel.NomeFantasiaFornecedor,
                    CNPJ = fcViewModel.CNPJ,
                    Website = fcViewModel.Website,
                    Ativo = fcViewModel.Ativo
                };

                var contato = new Contato()
                {
                    Nome = fcViewModel.Nome,
                    Email = fcViewModel.Email,
                    Telefone1 = fcViewModel.Telefone1,
                    Telefone2 = fcViewModel.Telefone2,
                    Telefone3 = fcViewModel.Telefone3

                };
                db.Fornecedores.Add(fornecedor);
                if (contato.Nome != null)
                {
                    db.Contatos.Add(contato);    
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fcViewModel);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedorViewModel = db.Fornecedores.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.FornecedorId = id;
            return View(fornecedorViewModel);
        }
        
        public ActionResult AdicionarContato(int id)
        {
            ViewBag.FornecedorId = id;
            return PartialView("_AdicionarContato");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                var contato = new Contato()
                {
                    FornecedorId = contatoViewModel.FornecedorId,
                    Nome = contatoViewModel.Nome,
                    Email = contatoViewModel.Email,
                    Telefone1 = contatoViewModel.Telefone1,
                    Telefone2 = contatoViewModel.Telefone2,
                    Telefone3 = contatoViewModel.Telefone3

                };
                if (contato.Nome != null)
                {
                    db.Contatos.Add(contato);
                }

                db.SaveChanges();

                string url = Url.Action("ListarContatos", "Fornecedores", new { id = contatoViewModel.FornecedorId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", contatoViewModel);
        }
        public ActionResult ListarContatos(int id)
        {
            ViewBag.FornecedorId = id;
            return PartialView("_ContatosList", db.Fornecedores.Find(id).Contatos);
        }

        public ActionResult AtualizarContato(int? id)
        {
            return PartialView("_AtualizarContato", db.Contatos.Find(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                var contato = new Contato()
                {
                    FornecedorId = contatoViewModel.FornecedorId,
                    ContatoId = contatoViewModel.ContatoId,
                    Nome = contatoViewModel.Nome,
                    Email = contatoViewModel.Email,
                    Telefone1 = contatoViewModel.Telefone1,
                    Telefone2 = contatoViewModel.Telefone2,
                    Telefone3 = contatoViewModel.Telefone3

                };
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                

                string url = Url.Action("ListarContatos", "Fornecedores", new { id = contatoViewModel.FornecedorId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarContato", contatoViewModel);
        }
        
    }
}