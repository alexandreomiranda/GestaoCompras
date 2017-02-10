using GestaoCompras.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoCompras.Controllers
{
    public class OrcamentosController : Controller
    {
        private GestaoComprasContext db = new GestaoComprasContext();

        public ActionResult Index()
        {
            return View(db.Orcamentos.ToList());
        }
    }
}