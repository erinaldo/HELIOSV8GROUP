using Helios.Retail.Helpers;
using Helios.Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = Helios.Cont.Business.Entity;
using BESG = Helios.Seguridad.Business.Entity;
using SA = Helios.Cont.WCFService.ServiceAccess;
using SASG = Helios.Seguridad.WCFService.ServiceAccess;

namespace Helios.Retail.Controllers
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

            usuario = new BESG.AutenticacionUsuario ();
            usuario.Alias = acc.Name;
            usuario.Contrasena = acc.Password;
            usuario.IDCliente = "1";// empresaSPK.FirstOrDefault.idclientespk 
            SelEmpresa = empresaSA.UbicarEmpresaRuc("12345678912"); 

            var ListaUnidadesNegocio = SA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa);

            if (ListaUnidadesNegocio != null || ListaUnidadesNegocio.Count > 0)
            {
                LoginInformation.Empresa = SelEmpresa;
                LoginInformation.Establecimiento = ListaUnidadesNegocio.Where(s => s.idCentroCosto  == 3 ).FirstOrDefault();
                usuario.IdEmpresa = "12345678912";
                usuario.IDEstablecimiento  = 3;
                if (autenticacionSA.AutenticarUsuario(ref usuario))
                {                   
                    var AutenticacionUsuario = usuario;
                    Session["username"] = AutenticacionUsuario.Alias;
                   // Session.t
                    //TODO: Crear login
                    //// Se obtiene los permisos necesarios
                    //AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(new AutorizacionRol() { IDCliente = SelEmpresa.idclientespk, IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol });

                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    LoginInformation.ListUsers = usuarioSA.ListadoUsuariosv2();
                    //ViewBag.UsurioLogin = usuario.CustomUsuario;

                //    var namm = Session["username"];
                    ViewBag.UserName = AutenticacionUsuario.Alias;
                    //return View("Dashboardv1");
                    //return View("~/Views/Dashboard/Dashboardv1.cshtml");
                    //return View("~/Views/Order/Create.cshtml");                                                     
                    //return RedirectToAction("~/Views/Order/Create.cshtml", model);
                    return Redirect("~/Order/Create");
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