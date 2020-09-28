using Helios.Cont.Web.Helpers;
using Helios.Cont.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = Helios.Cont.Business.Entity;
using BESG = Helios.Seguridad.Business.Entity;
using SA = Helios.Cont.WCFService.ServiceAccess;
using SASG = Helios.Seguridad.WCFService.ServiceAccess;
namespace Helios.Cont.Web.Controllers
{           
    public class AccountController : Controller
    {
        BESG.AutenticacionUsuario usuario;
        BE.empresa SelEmpresa;
     //   BE.clientesSoftPack clienteSoftpack;
        SA.empresaSA empresaSA = new SA.empresaSA();
        SASG.AutenticacionUsuarioSA autenticacionSA = new SASG.AutenticacionUsuarioSA();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            Helios.Cont.WCFService.ServiceAccess.establecimientoSA SA = new SA.establecimientoSA();

            usuario = new BESG.AutenticacionUsuario();
            usuario.Alias = acc.Name;
            usuario.Contrasena = acc.Password;
            usuario.IDCliente = "1";// empresaSPK.FirstOrDefault.idclientespk 
            SelEmpresa = empresaSA.UbicarEmpresaRuc("20602665063");

            var ListaUnidadesNegocio = SA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa);


            if (ListaUnidadesNegocio  != null || ListaUnidadesNegocio.Count > 0)
            {
                LoginInformation.Empresa = SelEmpresa;
                LoginInformation.Establecimiento = ListaUnidadesNegocio.Where(s=>s.TipoEstab == "UN").FirstOrDefault();

                if (autenticacionSA.AutenticarUsuario(ref usuario))
                {                                                                                
                    // Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
                    var AutenticacionUsuario = usuario;
                    Session["username"] = AutenticacionUsuario.Alias;

                    //// Se obtiene los permisos necesarios
                    //AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(new AutorizacionRol() { IDCliente = SelEmpresa.idclientespk, IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol });

                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();


                    SA.documentoVentaAbarrotesSA documentoVentaAbarrotesSA = new SA.documentoVentaAbarrotesSA();
                    var count = documentoVentaAbarrotesSA.GetTransferenciaEnTransitoCount(new BE.documentoventaAbarrotes()
                    {
                        idEmpresa = SelEmpresa.idEmpresa,
                        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                        estadoEntrega = "0",
                    });

                    LoginInformation.TransferTransitCount = count;

                    //SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
                    ////idEmpresa = "20604303495",
                    //if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                    //{
                    //    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                    //    {
                    //        idEmpresa = LoginInformation.Empresa.idEmpresa,
                    //        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                    //        descripcionItem = ""
                    //    });
                    //    Product.GetDetalleitems = Products;
                    //}


                    //return View("Dashboardv1");                    
                    //return View("~/Views/Order/NuevaOrden2.cshtml");
                    return Redirect("~/Order/NuevaOrden2");
                }
                else
                {
                    return View("~/Views/Account/Login.cshtml");
                    //return View("Login");
                }

            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
                                                                
        }

        public JsonResult checkSession()
        {
            bool s;// = new sessionClass();
            //if (Session["UserName"] != null)
            //{
            //    s = true;
            //}
            //else
            //{
            Session.Remove("UserName");
                s = false;

            //}
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}