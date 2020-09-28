using Helios.Cont.WCFService.ServiceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Helios.Cont.Presentation.MvcProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            empresaSA SA = new empresaSA();
            var lista = SA.ObtenerListaEmpresas();
         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}