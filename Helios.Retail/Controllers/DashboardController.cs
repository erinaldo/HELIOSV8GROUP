using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Retail.Helpers;
using Helios.Retail.Models;

namespace Helios.Retail.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboardv1()
        {
            if (Session["username"] == null)
            {
                //return RedirectToAction("Login", "Account");
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                ViewBag.username = Session["username"];

               // SA.detalleitemsSA prodSA = new SA.detalleitemsSA();

                //var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                //{
                //    idEmpresa = LoginInformation.Empresa.idEmpresa,
                //    idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                //    descripcionItem = ""
                //});
              //  Product.GetDetalleitems = Products;

                return View();
            }
        }

        public ActionResult Dashboardv2()
        {
            return View();
        }
    }
}