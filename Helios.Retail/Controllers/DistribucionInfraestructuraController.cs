using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = Helios.Cont.Business.Entity;
using SA = Helios.Cont.WCFService.ServiceAccess;
using Helios.Retail.Helpers;
using Helios.Retail.Models;

namespace Helios.Retail.Controllers
{
    public class DistribucionInfraestructuraController : Controller
    {


        private SA.distribucionInfraestructuraSA mesaSA = new SA.distribucionInfraestructuraSA();
        private List<string> estado = new List<string>();
        private List<BE.distribucionInfraestructura> listaDistribucion = new List<BE.distribucionInfraestructura>();
        private BE.distribucionInfraestructura DistribucionBE = new BE.distribucionInfraestructura();
        private string tipoEstado;


        [HttpGet]

        // GET: DistribucionInfraestructura
        public ActionResult Index()
        {

            var model = new DistribucionInfraestructuraModel();
                           
             listaDistribucion = mesaSA.getInfraestructura(new BE.distribucionInfraestructura()
            {
                idEmpresa = "12345678912",
                idEstablecimiento = 3,
                tipo = "VPN",
                estado = "A",
                usuarioActualizacion = "U,A,P,L",
                Categoria = "1",
            });

            model.ListaDistribucionInfraestructuras  = listaDistribucion;
          return View(model);

        }


        public ActionResult UpdateInfraestructuraEstado()
        {
                     
            var model = new DistribucionInfraestructuraModel();

            DistribucionBE = mesaSA.updateDistribucionxID(new BE.distribucionInfraestructura()
            {
                idEmpresa = "12345678912",
                idEstablecimiento = 3,
                tipo = "VPN",
                estado = "U",             
            });

            model.distribucionInfraestructuraBE = DistribucionBE;
            return View(model);

        }

    }
}