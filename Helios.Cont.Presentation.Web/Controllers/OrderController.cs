using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Presentation.Web.Models;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using SoftPackERP_Sunat;

namespace Helios.Cont.Presentation.Web.Controllers
{
    public class OrderController : Controller
    {
        SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
        List<BE.detalleitems> Products = new List<BE.detalleitems>();
        public OrderController()
        {
            
        }

        public ActionResult LoadOrders(string mes, string anio)
        {
            var periodo = $"{mes}/{anio}";
            SA.documentoVentaAbarrotesSA DocumentoVentaSA = new SA.documentoVentaAbarrotesSA();
            var ListaPedidos = DocumentoVentaSA.GetListarVentasPeriodoXTipo(3, periodo, "VNP").OrderByDescending(v=>v.idDocumento).ToList();
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListadoOrdenes()
        {                       
            if (Product.GetUsuariosSistemas == null)
            {
                Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
            }

            return View(new ViewModelGeneral());
        }

            // GET: Order
        public ActionResult NuevaOrden()
        {
            //Products = prodSA.GetProductosWithInventario(new BE.detalleitems
            //{
            //    idEmpresa = "10735115311",
            //    idEstablecimiento = 10,
            //    descripcionItem = ""
            //});
            return View();
        }

        public ActionResult Edit(int id)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var doc = ventaSA.GetVentaID(new BE.documento() { idDocumento = id });

            return View(doc);
        }

        #region Vista Nuevo Pedido

        public JsonResult EliminarPedido(int idDocumento)
        {
            SA.DocumentoSA ventaSA = new SA.DocumentoSA();
            ventaSA.EliminarPedidos(new BE.documento() { idDocumento = idDocumento });            
            return new JsonResult { Data = new { status = true } };
        }

        public JsonResult GetUbicarVendedor(string codigoVendedor)
        {
            var  listaUsuarios = Product.GetUsuariosSistemas;
            var usuarioSel = listaUsuarios.Where(u => u.codigo == codigoVendedor).SingleOrDefault();
            if (usuarioSel != null){
                return Json(usuarioSel, JsonRequestBehavior.AllowGet);
            }
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }          
        }

        public JsonResult GetStudents(string term)
        {            
            //  List<string> prods;
            //  prods = p.Detalleitems;
            term = term.ToUpper().Trim();
            if (Product.GetDetalleitems != null)
            {
                var prods2 = Product.GetDetalleitems.Where(x => x.descripcionItem.Contains(term)).Select(c => new { id = c.codigodetalle, value = c.descripcionItem });
                return Json(prods2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                throw new Exception("Actualizar lista de productos");
                //return Json(null, JsonRequestBehavior.AllowGet);
            }                               
        }

        #region Entidades
        public JsonResult GetCliente(string nrodoc, string tipo)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();
            BE.entidad ent = new BE.entidad();
            switch (tipo)
            {
                case "Varios":
                    var cli = entidadSA.UbicarEntidadVarios("VR", "20604303495", "");
                    ent = cli;
                    break;

                case "Cliente":

                    if (nrodoc.ToString().Trim().Length == 8)
                    {
                        var nombres = GetConsultarDNIReniec(nrodoc);
                        ent.nrodoc = nrodoc;
                        ent.nombreCompleto = nombres;
                        ent.tipoDoc = "1";
                        ent.tipoPersona = "N";
                        ent.direccion = "-";

                        var existeEnDB = entidadSA.UbicarEntidadPorRucNro("20604303495", "CL", nrodoc);

                        if (existeEnDB == null)
                        {
                            ent = GrabarEntidadRapida(ent);

                        }
                        else
                        {
                            ent = existeEnDB;
                        }

                    }
                    else if (nrodoc.ToString().Trim().Length == 11)
                    {
                        var existeEnDB = entidadSA.UbicarEntidadPorRucNro("20604303495", "CL", nrodoc);

                        if (existeEnDB == null)
                        {
                            var obj = GetApi(nrodoc);
                            ent = obj;
                            ent = GrabarEntidadRapida(ent);
                        }
                        else
                        {
                            ent = existeEnDB;
                        }
                    }
                    break;
                default:
                    break;
            }
            return Json(ent, JsonRequestBehavior.AllowGet);
        }

        private BE.entidad GetApi(string nroruc)
        {
            BE.entidad SelRazon;
            SelRazon = new BE.entidad();
            using (var client = new HttpClient())
            {

                if (nroruc.ToString().Trim().Substring(0, 1) == "1")
                {
                    SelRazon.tipoPersona = "N";
                }
                else if (nroruc.ToString().Trim().Substring(0, 1) == "2")
                {
                    SelRazon.tipoPersona = "J";
                }

                client.BaseAddress = new Uri("https://api.sunat.cloud/ruc/");
                //HTTP GET
                var responseTask = client.GetAsync(nroruc);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CompanyJuridico>();
                    readTask.Wait();

                    var students = readTask.Result;

                    SelRazon.tipoDoc = "6";
                    SelRazon.tipoEntidad = "CL";
                    SelRazon.nombreCompleto = students.RazonSocial;
                    SelRazon.nombreContacto = students.RazonSocial;
                    SelRazon.estado = students.ContribuyenteEstado;
                    SelRazon.nrodoc = students.Ruc;
                    SelRazon.direccion = students.DomicilioFiscal;
                }
            }
            return SelRazon;
        }

        public JsonResult ClienteSelID(int idEntidad)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();
            var entidad = entidadSA.UbicarEntidadPorID(idEntidad).First();
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertCliente(BE.entidad entidad)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();

            switch (entidad.idEntidad)
            {
                case 0:
                    var codIdEntidad = entidadSA.GrabarEntidad(entidad);
                    entidad.idEntidad = codIdEntidad;
                    break;

                default:
                    entidadSA.UpdateEntidad(entidad);
                    break;
            }
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        private BE.entidad GrabarEntidadRapida(BE.entidad SelRazon)
        {
            BE.entidad obEntidad = new BE.entidad();
            SA.entidadSA entidadSA = new SA.entidadSA();
            try
            {
                // Se asigna cada uno de los datos registrados                   
                obEntidad.idEmpresa = "20604303495";
                obEntidad.idOrganizacion = 3;
                obEntidad.tipoEntidad = "CL";
                obEntidad.tipoDoc = SelRazon.tipoDoc;
                obEntidad.tipoPersona = SelRazon.tipoPersona;
                obEntidad.nrodoc = SelRazon.nrodoc;
                obEntidad.nombreCompleto = SelRazon.nombreCompleto;
                obEntidad.cuentaAsiento = "1213";
                obEntidad.direccion = SelRazon.direccion;
                obEntidad.estado = General.Constantes.StatusEntidad.Activo;
                int codx = entidadSA.GrabarEntidad(obEntidad);
                obEntidad.idEntidad = codx;

            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception(ex.Message);
            }
            return obEntidad;
        }

        private string GetConsultarDNIReniec(string Dni)
        {
            WebClient CLIENTE = new WebClient();
            Stream PAGINA = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" + Dni);
            StreamReader LECTOR = new StreamReader(PAGINA);
            string MIHTML = LECTOR.ReadToEnd();
            // Dim array = MIHTML.Split("|")

            var nombres = MIHTML.Replace("|", " ");
            return nombres.Trim();
        }

        #endregion

        public JsonResult getProductCategories()
        {
            List<Category> categories;
            categories = Product.GetCategories();
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryID)
        {
            //var ListProducts = Product.GetProducts();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            where cat.equivalencia_id.Equals(categoryID)
                            select cat).ToList();


            //  var Catalogos = Product.GetDetalleitems.Select(s => s.detalleitem_equivalencias.Select(q => q.detalleitemequivalencia_catalogos.Where(c => c.equivalencia_id == categoryID).Select(eq => new { eq.idCatalogo, eq.nombre_corto }))).ToList();
            //    var products = ListProducts.Where(a => a.CategoryId.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult { Data = consulta, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getPrecios(int catalogoID)
        {
            //var ListProducts = Product.GetProducts();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            from price in cat.detalleitemequivalencia_precios
                            where price.idCatalogo.Equals(catalogoID)
                            select price).ToList();


            //  var Catalogos = Product.GetDetalleitems.Select(s => s.detalleitem_equivalencias.Select(q => q.detalleitemequivalencia_catalogos.Where(c => c.equivalencia_id == categoryID).Select(eq => new { eq.idCatalogo, eq.nombre_corto }))).ToList();
            //    var products = ListProducts.Where(a => a.CategoryId.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult { Data = consulta, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }                    

        public JsonResult getUnidades(int ProductID)
        {
            var ListProducts = Product.GetDetalleitems;
            var Produc = ListProducts.Where(s => s.codigodetalle == ProductID).SingleOrDefault();
            return new JsonResult { Data = Produc.detalleitem_equivalencias.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(BE.documentoventaAbarrotes order)
        {
            calculosVenta(order);
            DocumentoOperation.SaveDocumentoVenta(order);
          
            return new JsonResult { Data = new { status = true } };
        }

        private void calculosVenta(BE.documentoventaAbarrotes order)
        {
            var total = order.documentoventaAbarrotesDet.Sum(s=>s.importeMN).GetValueOrDefault();
            var BaseImponible = Math.Round((decimal)General.Constantes.CalculoBaseImponible(total, (decimal)1.18), 2);
            var Iva = total - BaseImponible;

            order.igv01 = Iva;
            order.bi01 = BaseImponible;
            order.ImporteNacional = total;
            order.ImporteExtranjero = 0;

        }

        public JsonResult GetCalculoPrecio(int idCatalogo,decimal? cant)
        {
            BE.detalleitemequivalencia_precios prec = new BE.detalleitemequivalencia_precios();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            where cat.idCatalogo.Equals(idCatalogo)
                            select cat).SingleOrDefault();

           var precioVenta = Product.GetCalculoPrecioVenta(cant.GetValueOrDefault(), consulta.codigodetalle, consulta.equivalencia_id, consulta.idCatalogo);

            prec.precio = precioVenta;

            return Json(prec, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}