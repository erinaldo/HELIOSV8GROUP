using Helios.Cont.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Web.Helpers;

using static Helios.General.Constantes;
using Helios.Cont.Business.Entity;

namespace Helios.Cont.Web.Controllers
{
    public class LogisticsController : Controller
    {
        // GET: Logistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagementPrices()
        {

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(int pageIndex, string sortName, string sortDirection, String Text)
        {

            var productSA = new SA.detalleitemsSA();
            var listaProductos = new List<BE.detalleitems>();

            if (pageIndex == 1)
            {
                LoginInformation.ListProducts = productSA.GetProductosWithEquivalencias(new BE.detalleitems()
                {
                    idEmpresa = LoginInformation.Empresa.idEmpresa,
                    idEstablecimiento = 3,
                    descripcionItem = Text
                });

                listaProductos = LoginInformation.ListProducts;
            }
            else if(pageIndex > 1)
            {
                listaProductos = LoginInformation.ListProducts;
            }
            

            //var listaProductos = productSA.GetProductosWithEquivalencias(new BE.detalleitems()
            //{
            //    idEmpresa = LoginInformation.Empresa.idEmpresa,
            //    idEstablecimiento = 3,
            //    descripcionItem = Text
            //});


            ProductModel model = new ProductModel();
            model.PageIndex = pageIndex;
            model.PageSize = 5;
            model.RecordCount = listaProductos.Count();
            int startIndex = (pageIndex - 1) * model.PageSize;

            //switch (sortName)
            //{
            //    case "CustomerID":
            //    case "":
            //        if (sortDirection == "ASC")
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderBy(customer => customer.CustomerID)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        else
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderByDescending(customer => customer.CustomerID)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        break;
            //    case "ContactName":
            //        if (sortDirection == "ASC")
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderBy(customer => customer.ContactName)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        else
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderByDescending(customer => customer.ContactName)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        break;
            //    case "City":
            //        if (sortDirection == "ASC")
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderBy(customer => customer.City)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        else
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderByDescending(customer => customer.City)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        break;
            //    case "Country":
            //        if (sortDirection == "ASC")
            //        {
            //            model.Customers = (from customer in entities.Customers
            //                               select customer)
            //                    .OrderBy(customer => customer.Country)
            //                    .Skip(startIndex)
            //                    .Take(model.PageSize).ToList();
            //        }
            //        else
           //         {
                        model.Detalleitems = (from customer in listaProductos
                                           select customer)
                                .OrderByDescending(customer => customer.descripcionItem)
                                .Skip(startIndex)
                                .Take(model.PageSize).ToList();
            //        }
            //        break;
            //}

            return Json(model);
        }


        [HttpGet]
        public JsonResult GetProductSelText(string Text)
        {
            var productSA = new SA.detalleitemsSA();
            var listaProductos = productSA.GetProductosWithEquivalencias(new BE.detalleitems()
            {
                idEmpresa = LoginInformation.Empresa.idEmpresa,
                idEstablecimiento = 3,
                descripcionItem = Text
            });

            return Json(listaProductos, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetTransferenciasEnTransito()
        {
           // var periodo = new DateTime(int.Parse(anio), int.Parse(mes), 1);
            var ventaSA = new SA.documentoVentaAbarrotesSA();
            var ListaPedidos = ventaSA.GetTransferenciaEnTransito(new BE.documentoventaAbarrotes() { estadoEntrega = "0", idEmpresa = LoginInformation.Empresa.idEmpresa });
            LoginInformation.documentoventaAbarrotesList = ListaPedidos;
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListTransfersTransit()
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                if (Product.GetUsuariosSistemas == null)
                {
                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
                }
                return View(new ViewModelGeneral());
            }          
        }
        

        public ActionResult GetOtrasEntradasPeriodo(string mes, string anio)
        {
            var periodo = $"{mes}/{anio}";
            var CompraSA = new SA.DocumentoCompraSA();
            var ListaPedidos = CompraSA.GetListarPorPeriodoEntradas(LoginInformation.Empresa .idEmpresa , LoginInformation.Establecimiento.idCentroCosto, periodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta .XUNIDAD_ORGANICA ).Where(o => o.tipoCompra == TIPO_COMPRA.OTRAS_ENTRADAS).ToList();
            LoginInformation.documentocomprasList = ListaPedidos;
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AnularEntrada(int idDocumento)
        {
            var CompraSA = new SA.DocumentoCompraSA();
            if (Session["username"] != null)
            {
                CompraSA.AnularEntradainv(new BE.documento() { idDocumento = idDocumento });               
                return new JsonResult { Data = new { status = true } };

            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }

        }

        public ActionResult GetTransferenciasPeriodo(string mes, string anio)
        {
            var periodo = new DateTime(int.Parse(anio), int.Parse(mes), 1);
            var ventaSA = new SA.documentoVentaAbarrotesSA();
            var ListaPedidos = ventaSA.GetTransferenciasPeriodo(new BE.documentoventaAbarrotes() {fechaDoc = periodo, idEmpresa = LoginInformation.Empresa.idEmpresa});
            LoginInformation.documentoventaAbarrotesList = ListaPedidos;
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductSelAlmacenText(string Text, int idalmacen)
        {
            var productSA = new SA.detalleitemsSA();
            var listaProductos = productSA.GetProductosWithInventarioAlmacen(new BE.detalleitems()
            {
                idEmpresa = LoginInformation.Empresa.idEmpresa,
                idEstablecimiento = 3,
                descripcionItem = Text,
                idAlmacen = idalmacen,
            });

            return Json(listaProductos, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult NewPrice(BE.detalleitemequivalencia_precios priceObj)
        {
            var precioSA = new SA.detalleitemequivalencia_preciosSA();

            var obj = new BE.detalleitemequivalencia_precios()
            {
                Action = BE.BaseBE.EntityAction.INSERT,
                idCatalogo = priceObj.idCatalogo,
                equivalencia_id = priceObj.equivalencia_id,
                codigodetalle = priceObj.codigodetalle,
                rango_inicio = priceObj.rango_inicio,
                precioCode = "New price",
                precio = priceObj.precio,
                precioCredito = priceObj.precioCredito,
                usuarioActualizacion = "1",
                estado = 1,
                fechaActualizacion = DateTime.Now,
            };
            var prec = precioSA.PrecioEquivalenciaSave(obj);
            return Json(new { data = prec }, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { status = true } };
        }

        [HttpPost]
        public JsonResult EditingPrice(BE.detalleitemequivalencia_precios priceObj)
        {
            var precioSA = new SA.detalleitemequivalencia_preciosSA();

            var obj = new BE.detalleitemequivalencia_precios()
            {
                Action =  BE.BaseBE.EntityAction.UPDATE,
                idCatalogo = priceObj.idCatalogo,
                precio_id = priceObj.precio_id,
                rango_inicio = priceObj.rango_inicio,
                equivalencia_id = priceObj.equivalencia_id,
                codigodetalle = priceObj.codigodetalle,
                precioCode = priceObj.precioCode,
                precio = priceObj.precio,
                precioUSD = priceObj.precioUSD.GetValueOrDefault(),
                precioCredito = priceObj.precioCredito,
                precioCreditoUSD = priceObj.precioCreditoUSD.GetValueOrDefault(),
                usuarioActualizacion = "1",
                estado = 1,
                fechaActualizacion = DateTime.Now,
            };       
            precioSA.PrecioEquivalenciaSave(obj);
            return new JsonResult { Data = new { status = true } };
        }

        [HttpPost]
        public JsonResult saveOtherPurchase(BE.documento order)        //    public JsonResult saveOtherPurchase(BE.documento order, List<BE.documentocompradetalle> lista)
        {
            DocumentoOperation.SaveOthersPurchase(order);
            //  ImprimirPedido(order);

            //SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            //ventaSA.GrabarVentaEquivalenciaXInfra(order);
            //calculosVenta(order);
            //DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
            // return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveTransfer(BE.documento order)
        {
            DocumentoOperation.SaveTransfer(order);
            return new JsonResult { Data = new { status = true } };
        }

        [HttpPost]
        public JsonResult ConfirmTransfer(BE.documento order)
        {            
            DocumentoOperation.ConfirmGiveTransfer(order);
            return new JsonResult { Data = new { status = true } };
        }


        public ActionResult CreateWarehouseTransfer()
        {
            var ClienteVarios = new BE.entidad();
            //SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
            SA.entidadSA entidadSA = new SA.entidadSA();

            LogisticViewModel itemViewModel = new LogisticViewModel();
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                //idEmpresa = "20604303495",
                //if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                //{
                //    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                //    {
                //        idEmpresa = LoginInformation.Empresa.idEmpresa,
                //        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                //        descripcionItem = ""
                //    });
                //    Product.GetDetalleitems = Products;
                //    itemViewModel.GetDetalleitems = Products;
                //}
                //else
                //{
                //    itemViewModel.GetDetalleitems = Product.GetDetalleitems;
                //}


                ClienteVarios = entidadSA.UbicarEntidadVarios("VR", LoginInformation.Empresa.idEmpresa, "", LoginInformation.Establecimiento.idCentroCosto);
                //ViewBag.ClienteVarios = ClienteVarios;
                itemViewModel.EntidadVarios = ClienteVarios;
                itemViewModel.almacens = GetAlmacenes();
                return View(itemViewModel);
            }
        }
        public ActionResult IndexOtrasEntradas()
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                if (Product.GetUsuariosSistemas == null)
                {
                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
                }
                return View(new ViewModelGeneral());
            }
        }

        public ActionResult IndexOtrasSalidas()
        {
            return View();
        }

        public ActionResult IndexTransferencias()
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                if (Product.GetUsuariosSistemas == null)
                {
                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
                }
                return View(new ViewModelGeneral());
            }
        }

        public ActionResult CreateWarehouse()
        {
            var ClienteVarios = new BE.entidad();
         //   SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
            SA.entidadSA entidadSA = new SA.entidadSA();
            
            LogisticViewModel itemViewModel = new LogisticViewModel();
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {             
                //idEmpresa = "20604303495",
                //if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                //{
                //    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                //    {
                //        idEmpresa = LoginInformation.Empresa.idEmpresa,
                //        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                //        descripcionItem = ""
                //    });
                //    Product.GetDetalleitems = Products;
                //    itemViewModel.GetDetalleitems = Products;
                //}
                //else
                //{
                //    itemViewModel.GetDetalleitems = Product.GetDetalleitems;
                //}


                ClienteVarios = entidadSA.UbicarEntidadVarios("VR", LoginInformation.Empresa.idEmpresa, "", LoginInformation.Establecimiento .idCentroCosto );
                //ViewBag.ClienteVarios = ClienteVarios;
                itemViewModel.EntidadVarios = ClienteVarios;
                itemViewModel.almacens = GetAlmacenes();
                return View(itemViewModel);
            }
        }

        public ActionResult ViewWarehouse(int ID)
        {
            var compraSA = new SA.DocumentoCompraSA();
            var compra = compraSA.GetCompraID(new Business.Entity.documento() { idDocumento = ID });
            //var documentoOperacion = LoginInformation.documentocomprasList.Where(d => d.idDocumento == ID).SingleOrDefault();
            return PartialView("_ViewDetailsOtherPurchase", compra);         
        }

        public ActionResult ViewWarehouseTransfer(int ID)
        {          
            var documentoOperacion = LoginInformation.documentoventaAbarrotesList.Where(d => d.idDocumento == ID).SingleOrDefault();
            return PartialView("_ViewWarehouseTransfer", documentoOperacion);
        }

        private List<BE.almacen> GetAlmacenes()
        {
            SA.almacenSA almacenSA = new SA.almacenSA();
            var almacenBE = new almacen();

            almacenBE.idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto;
            almacenBE.idEmpresa = LoginInformation.Empresa.idEmpresa;
            almacenBE.TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA;




            var list = almacenSA.GetListar_almacenExceptAV(almacenBE);
            return list;
        }

        public ActionResult InventoryValued()
        {
            var almacenSA = new SA.almacenSA();
            var model = new LogisticViewModel();

            var almacenBE = new almacen();

            almacenBE.idEstablecimiento = 3;
            almacenBE.idEmpresa = LoginInformation.Empresa.idEmpresa;
            almacenBE.TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA;

            model.almacens = almacenSA.GetListar_almacenExceptAV(almacenBE);
            return View(model);
        }

        public ActionResult GetInventarioValorizado(int almacen, string tipo)
        {          
            SA.TotalesAlmacenSA TotalesAlmacenSA = new SA.TotalesAlmacenSA();
            var GetInventario = TotalesAlmacenSA.GetInventarioGeneral(
                new Business.Entity.totalesAlmacen()
                {
                    idAlmacen = almacen,
                    tipoExistencia = tipo,
                    InvAcumulado = true,
                }).OrderBy(o => o.descripcion).ToList();
            return Json(new { data = GetInventario }, JsonRequestBehavior.AllowGet);
        }
    }
}