using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GerApp.Models;

namespace GerApp.Controllers
{
    public class CadastreObjectsController : Controller
    {
        private EFContext conte = new EFContext();

        // GET: CadastreObjects
        public ActionResult Index()
        {
            //Vai ordenar(mostrar) a lista em funcao do tipo de cadastro
            return View(conte.CadastreObjects.OrderBy(x => x.TypeCadastre)); 
        }
    }
}