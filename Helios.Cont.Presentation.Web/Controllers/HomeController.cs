using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA = Helios.Cont.WCFService.ServiceAccess;
using SASG = Helios.Seguridad.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Presentation.Web.Models;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using SoftPackERP_Sunat;

namespace Helios.Cont.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
        List<BE.detalleitems> Products;


        public ActionResult Index()
        {
            SASG.UsuarioSA usuarioSA = new SASG.UsuarioSA();

            Products = prodSA.GetProductosWithInventario(new BE.detalleitems
            {
                idEmpresa = "20604303495",
                idEstablecimiento = 3,
                descripcionItem = ""
            });

            Product.GetDetalleitems = Products;
            Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
            ViewBag.Title = "SPK-Comercial";
            return View(Products);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<BE.detalleitems> prods;
            if (string.IsNullOrEmpty(searchTerm))
            {
                Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                {
                    idEmpresa = "10735115311",
                    idEstablecimiento = 10,
                    descripcionItem = ""
                });
                prods = Products.ToList();
            }
            else
            {
                prods = prodSA.GetProductosWithInventario(new BE.detalleitems
                {
                    idEmpresa = "10735115311",
                    idEstablecimiento = 10,
                    descripcionItem = searchTerm
                });
            }
            return View(prods);
        }


        public JsonResult GetStudents(string term)
        {
            //  List<string> prods;
            //  prods = p.Detalleitems;
            var prods2 = Product.GetDetalleitems.Where(x => x.descripcionItem.StartsWith(term)).Select(c => new { id = c.codigodetalle, value = c.descripcionItem });
            return Json(prods2, JsonRequestBehavior.AllowGet);
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


        //public JsonResult getProducts(object categoryID)
        //{
        //    var ListProducts = Product.GetProducts();
        //    var products = ListProducts.Where(a => a.CategoryId.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

        //    return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public JsonResult getProducts(string para1, string para2)
        //{
        //    var ListProducts = Product.GetProducts();
        //    var products = ListProducts.Where(a => a.CategoryId.Equals(1)).OrderBy(a => a.ProductName).ToList();

        //    return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

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

            //bool status = false;
            //DateTime dateOrg;
            //var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            //if (isValidDate)
            //{
            //    order.OrderDate = dateOrg;
            //}

            //var isValidModel = TryUpdateModel(order);
            //if (isValidModel)
            //{
            //    using (MyDatabaseEntities dc = new MyDatabaseEntities())
            //    {
            //        dc.OrderMasters.Add(order);
            //        dc.SaveChanges();
            //        status = true;
            //    }
            //}
            return new JsonResult { Data = new { status = true } };
        }

        private void calculosVenta(BE.documentoventaAbarrotes order)
        {
            var total = order.ImporteNacional;
            var BaseImponible = Math.Round((decimal)General.Constantes.CalculoBaseImponible(total.GetValueOrDefault(), (decimal)1.18),2);
            var Iva = total - BaseImponible;

            order.igv01 = Iva;
            order.bi01 = BaseImponible;

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

        //public JsonResult getUnidades(BE.detalleitems p)
        //{
        //    var ListProducts = Product.GetDetalleitems;
        //    var Produc = ListProducts.Where(s => s.codigodetalle == p.codigodetalle).SingleOrDefault();
        //    return new JsonResult { Data = Produc.detalleitem_equivalencias.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public JsonResult getCatalogos(int EquivalenciaID)
        //{
        //    var ListProducts = Product.GetDetalleitems;
        //    var Produc = ListProducts.Where(s => s.codigodetalle == ProductID).SingleOrDefault();
        //    return new JsonResult { Data = Produc.detalleitem_equivalencias.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
    }
}