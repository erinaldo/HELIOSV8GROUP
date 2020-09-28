using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Web.Helpers
{
    public static class LoginInformation
    {

        public static Helios.Cont.Business.Entity.empresa Empresa { get; set; }

        public static Helios.Cont.Business.Entity.centrocosto Establecimiento { get; set; }

        public static List<Helios.Seguridad.Business.Entity.Usuario> ListUsers;

        public static List<Helios.Cont.Business.Entity.detalleitems> ListProducts;

        public static List<Helios.Cont.Business.Entity.documentoventaAbarrotes> documentoventaAbarrotesList { get; set; }

        public static List<Helios.Cont.Business.Entity.documentocompra> documentocomprasList { get; set; }

        public static int TransferTransitCount { get; set; }
    }
}