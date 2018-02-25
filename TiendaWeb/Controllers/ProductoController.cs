using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaWeb.Models;
using TiendaWeb.Repository;

namespace TiendaWeb.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ProductoRepository pr = new ProductoRepository();
            List<Producto> producto = pr.getProductoAll();

            ViewBag.resultadoParaLaVista = producto;
           

            return View();
        }

        public ActionResult FormularioNuevo()
        {
            return View();
        }

    }
}