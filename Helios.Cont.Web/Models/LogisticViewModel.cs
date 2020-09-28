using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Web.Models
{
    public class LogisticViewModel
    {
        public List<almacen> almacens { get; set; }

        public List<totalesAlmacen> totalesAlmacens { get; set; }

        public List<item> Categories;

        public List<detalleitems> GetDetalleitems;

        public entidad EntidadVarios;
    }
}