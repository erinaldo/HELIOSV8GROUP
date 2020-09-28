using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginUsuario
    {

        public string Name { get; set; }

        public string Password { get; set; }

        public string prueba { get; set; }

        public static Helios.Cont.Business.Entity.empresa Empresa { get; set; }

        public static Helios.Cont.Business.Entity.centrocosto Establecimiento { get; set; }

       
        public static List<Helios.Seguridad.Business.Entity.Usuario> ListUsers;

    }
}
