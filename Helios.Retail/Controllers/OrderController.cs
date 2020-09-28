using Helios.Retail.Helpers;
using Helios.Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = Helios.Cont.Business.Entity;
using SA = Helios.Cont.WCFService.ServiceAccess ;

namespace Helios.Retail.Controllers
{
    public class OrderController : Controller
    {
        private SA.distribucionInfraestructuraSA mesaSA = new SA.distribucionInfraestructuraSA();
        private SA.itemSA ItemSA = new SA.itemSA();
        private SA.detalleitemsSA productSA = new SA.detalleitemsSA();

        public OrderController()
        {

        }

        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ItemViewModel();
            var ListaMesas = mesaSA.getInfraestructura(new BE.distribucionInfraestructura()
            {
                idEmpresa = "12345678912",
                idEstablecimiento = 3,
                tipo = "VPN",
                estado = "A",
                usuarioActualizacion = "U,A,P,L",
                Categoria = "1",
            });
            model.ListaDistribucionInfraestructuras  = ListaMesas;
            model.UsuariosSistema = LoginInformation.ListUsers;
            return View(model);
        }


        [HttpGet]
        public ActionResult ConsultarSeleccionMesa(int ID, string nombreMesa, string numeroMesa)
        {

            if (Session["username"] == null)
            {
                //return RedirectToAction("Login", "Account");
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                          

                SA.itemSA CatSA = new SA.itemSA();
                //  ViewBag.username = Session["username"];

                List<BE.item> listaItem = CatSA.GetListaItemPorEstable ( 3, "12345678912").ToList();


                BE.distribucionInfraestructura Mesa = new BE.distribucionInfraestructura()
                {
                    idDistribucion = ID,
                    descripcionDistribucion = nombreMesa + " " + numeroMesa
                };
                             
        
                var model = ToConvertItemViewModelxInfra(null, Mesa);
                
                var categoryPadre = new BE.item()
                {
                    idItem = 0,
                    descripcion = "Lista de Platos",
                    tipo = "P",
                    idPadre = 1
                };
                listaItem.Add(categoryPadre);
                model.Categories = (listaItem);
                return View(model);
            }           
        }

        [HttpGet]
        public ActionResult Create()
        {

            if (Session["username"] == null)
            {
                //return RedirectToAction("Login", "Account");
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                SA.itemSA CatSA = new SA.itemSA();
                //  ViewBag.username = Session["username"];

                

                List<BE.item> listaItem = CatSA.GetListaItemPorEstable ( 3, "12345678912").ToList();
               
                var ListaMesas = mesaSA.getInfraestructura(new BE.distribucionInfraestructura()
                {
                    idEmpresa = "12345678912",
                    idEstablecimiento = 3,
                    tipo = "VPN",
                    estado = "A",
                    usuarioActualizacion = "U,A,P,L",
                    Categoria = "1",
                });

                this.ViewBag.CountryList = GetCountryList(ListaMesas);

                //ItemSA.GetListaItemPorEstable(3).Where(c => c.tipo == "M").ToList()

                var model = ToConvertItemViewModel(null, ListaMesas);

                // var consulta = (listaItem.Where(o => o.tipo == "C")).ToList();
                var categoryPadre = new BE.item()
                {
                    idItem = 0,
                    descripcion = "Lista de Platos",
                    tipo = "P",
                    idPadre = 1
                };
                listaItem.Add(categoryPadre);
                model.Categories=(listaItem);
                return View(model);
            }            
        }

        private IEnumerable<SelectListItem> GetCountryList(List<BE.distribucionInfraestructura> distribucionInfraestructuras)
        {
            // Initialization.
            SelectList lstobj = null;

            try
            {
                // Loading.
                var list = distribucionInfraestructuras
                                  .Select(p =>
                                            new SelectListItem
                                            {
                                                Value = p.idDistribucion.ToString(),
                                                Text = $"{p.descripcionDistribucion}-{p.numeracion}" 
                                            });

                // Setting.
                lstobj = new SelectList(list, "Value", "Text");
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // info.
            return lstobj;
        }

        private ItemViewModel ToConvertItemViewModel(List<BE.item> model, List<BE.distribucionInfraestructura> distribucionInfraestructuras)
        {
            ItemViewModel obj = new ItemViewModel();
            obj.items = model;
            obj.ListaDistribucionInfraestructuras  = distribucionInfraestructuras;
            return obj;
        }

        private ItemViewModel ToConvertItemViewModelxInfra(List<BE.item> model, BE.distribucionInfraestructura distribucionInfraestructuras)
        {
            ItemViewModel obj = new ItemViewModel();
            obj.items = model;
            obj.distribucionInfraestructuras  = distribucionInfraestructuras;
            return obj;
        }


        [HttpPost]
        public JsonResult saveOrder(BE.documento order)
        {
            DocumentoOperation.SaveOrder(order);
            ImprimirPedido(order);
          
            //SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            //ventaSA.GrabarVentaEquivalenciaXInfra(order);
            //calculosVenta(order);
            //DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
           // return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateMesaXDistribucionID(BE.distribucionInfraestructura  order)
        {
            DocumentoOperation.UpdateInfraestructuraXDistribucionID (order);
            //ImprimirPedido(order);

            //SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            //ventaSA.GrabarVentaEquivalenciaXInfra(order);
            //calculosVenta(order);
            //DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
            // return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        public void ImprimirPedido(BE.documento order)
        {
            DLLImpresion.TicketPedido print = new DLLImpresion.TicketPedido();          
            //TITULO
            print.AnadirLineaEmpresa("PEDIDO");

            //DATOS DE CABECERA
            //FECHA
            //
            //PEDIDO Y NUMERO DE PEDIDO
            //NOMBRE DEL MOZO
            //
            // NOMBRE DE MESA
            //
            //
            //
            print.AnadirLineaCaracteresDatosGEnerales(order.fechaProceso.ToString(),
                                                  "ADMIN",
                                                   "PEDIDO" + "-",
                                                    order.CustomNumero,
                                                    "",
                                                  order.documentoventaAbarrotes.nroOrdenVenta.ToString(), "NAC", "966557413");


            //DETALLES DE LOS PEDIDOS
            foreach (var item in order.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList())
            {
                //i/f (item.tipoVenta == "PL")
                //{
                    if (item.detalleAdicional != null)
                    {
                        if (item.tipoVenta == "PL") 
                            print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                        else
                            print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                }
                else
                {
                    if (item.tipoVenta == "PL")
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                    else
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                }                   
                    
            }
               // }
                //else
                //{
                //    if (item.detalleAdicional != null)
                //    {
                //        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                //    }
                //    else
                //    {
                //        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.unidad1, String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                //    }
                //}
            
            //NOMBRE DE LA IMPRESORA
            //NUMERO COPIAS DE IMPRESION
            print.ImprimeTicket("TICKET", 1);
        }

        [HttpGet]
        public JsonResult GetProductsSelCategory(int id)
        {
            //Creating List    
            var ListaProducts = productSA.GetProductosWithEquivalenciasXCat(new BE.detalleitems { idItem   =  id, idEmpresa = "12345678912",  idEstablecimiento = 3});
            return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMesas()
        {
            var ListaMesas = mesaSA.getInfraestructura(new BE.distribucionInfraestructura()
            {
                idEmpresa = "12345678912",
                idEstablecimiento = 3,
                tipo = "VPN",
                estado = "A",
                usuarioActualizacion = "U,A,P,L",
                Categoria = "1",
            });

          

            return Json(ListaMesas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductSelText(string Text)
        {           

            var listaProductos = productSA.GetProductosWithInventario(new BE.detalleitems()
            {
                idEmpresa = "12345678912",
                idEstablecimiento = 3,
                descripcionItem = Text
            });

            return Json(listaProductos, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetUbicarVendedor(string codigoVendedor)
        {
            Helios.Seguridad.Business.Entity.Usuario usuarioSel;
            if (LoginInformation.ListUsers == null)
            {
                Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                LoginInformation.ListUsers = usuarioSA.ListadoUsuariosv2();

                usuarioSel = LoginInformation.ListUsers.Where(u => u.codigo == codigoVendedor).SingleOrDefault();
            }
            else
            {
                usuarioSel = LoginInformation.ListUsers.Where(u => u.codigo == codigoVendedor).SingleOrDefault();
            }

            
            if (usuarioSel != null)
            {
                return Json(usuarioSel, JsonRequestBehavior.AllowGet);
            }
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LoadOrders(string mesa)
        {
            SA.documentoPedidoDetSA ventaSA = new SA.documentoPedidoDetSA();

            List<string> listaEntrega = new List<string>();
            listaEntrega.Add("DC");
            listaEntrega.Add("PN");
            listaEntrega.Add("PR");
            listaEntrega.Add("AN");

            List<string> listaTipoVenta = new List<string>();
            listaTipoVenta.Add("VP");
            listaTipoVenta.Add("VNP");
            listaTipoVenta.Add("VELC");
            listaTipoVenta.Add("NOTE");

            BE.documentoPedido documentoBE = new BE.documentoPedido();
            documentoBE.idEmpresa = "12345678912";
            documentoBE.idEstablecimiento = 3;
            documentoBE.ListaTipoVenta = new List<string>();
            documentoBE.ListaTipoVenta = listaTipoVenta;
            documentoBE.idCliente = int.Parse(mesa);
            documentoBE.ListaEstado = new List<string>();
            documentoBE.ListaEstado = listaEntrega;
            documentoBE.listaIdDistribucion = new List<string>();
            documentoBE.listaIdDistribucion.Add(mesa);

            var consulta = new List<BE.documentoventaAbarrotesDet>();
            consulta = ventaSA.GetUbicar_DocveNTAxIdDistribucion(documentoBE);
        
            return Json(new { data = consulta }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarPedido(int idDocumento, int secuencia,int idmesa)
        {
            if (Session["username"] != null)
            {
                SA.documentoVentaAbarrotesDetSA documentoventaSA = new SA.documentoVentaAbarrotesDetSA();
                BE.documentoventaAbarrotesDet documentoventaBE = new BE.documentoventaAbarrotesDet();

                documentoventaBE.secuencia = secuencia;
                documentoventaBE.idDocumento = idDocumento;
                documentoventaBE.idDistribucion = idmesa;
                documentoventaBE.IdEmpresa = "12345678912";
                documentoventaBE.estadoDistribucion = "A";

                documentoventaSA.DeleteItemVentaRestaurant(documentoventaBE);

                return new JsonResult { Data = new { status = true } };

            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }

        }

        public JsonResult GetPrintDocumento(int idmesa, string fecha, string vendedor, int id, string nameMesa)
        {
            DLLImpresion.TicketPedido print = new DLLImpresion.TicketPedido();
            SA.documentoVentaAbarrotesSA pedidoSA = new SA.documentoVentaAbarrotesSA();

            var doc = pedidoSA.GetImprimirPedido(new BE.documento() { idDocumento = id });

            //TITULO
            print.AnadirLineaEmpresa("PEDIDO");

            //DATOS DE CABECERA
            //FECHA
            //
            //PEDIDO Y NUMERO DE PEDIDO
            //NOMBRE DEL MOZO
            //
            // NOMBRE DE MESA
            //
            //
            //
            print.AnadirLineaCaracteresDatosGEnerales(fecha,
                                                  "ADMIN",
                                                   "PEDIDO" + "-",
                                                    vendedor,
                                                    "",
                                                  nameMesa.ToString(), "NAC", "966557413");


            //DETALLES DE LOS PEDIDOS

            foreach (var item in doc)
            {
                if (item.tipoVenta == "PL")
                {
                    if (item.detalleAdicional != null)
                    {
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                    }
                    else
                    {
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.unidad1, String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                    }
                }
                else
                {
                    if (item.detalleAdicional != null)
                    {
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                    }
                    else
                    {
                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.unidad1, String.Format("{0:0.00}", 0), String.Format("{0:0.00}", 0));
                    }
                }
            }
            //NOMBRE DE LA IMPRESORA
            //NUMERO COPIAS DE IMPRESION
            print.ImprimeTicket("TICKET", 1);
            //  return new JsonResult { Data = new { status = true }, JsonRequestBehavior.AllowGet() };
            //return Json(new { total = total, data = null }, JsonRequestBehavior.AllowGet);
            return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}