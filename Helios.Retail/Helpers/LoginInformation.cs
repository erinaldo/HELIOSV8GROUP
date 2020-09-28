using System.Collections.Generic;

namespace Helios.Retail.Helpers
{
    public static class LoginInformation
    {
        public static Helios.Cont.Business.Entity.empresa Empresa { get; set; }

        public static Helios.Cont.Business.Entity.centrocosto Establecimiento { get; set; }

        public static List<Helios.Seguridad.Business.Entity.Usuario> ListUsers;
    }
}