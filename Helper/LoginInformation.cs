using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
   public class LoginInformation
    {
        public static Helios.Cont.Business.Entity.empresa Empresa { get; set; }

        public static Helios.Cont.Business.Entity.centrocosto Establecimiento { get; set; }


        public static List<Helios.Seguridad.Business.Entity.Usuario> ListUsers;
    }
}
