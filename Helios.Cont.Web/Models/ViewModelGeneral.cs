using Helios.Cont.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Web.Models
{
    public class ViewModelGeneral
    {
        public IEnumerable<Seguridad.Business.Entity.Usuario> UsuariosSistema { get; private set; }        
       
        public ViewModelGeneral()
        {
            UsuariosSistema = Product.GetUsuariosSistemas;            
        }
    }
}