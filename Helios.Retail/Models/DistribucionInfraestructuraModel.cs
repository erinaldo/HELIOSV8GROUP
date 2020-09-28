using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE = Helios.Cont.Business.Entity;

namespace Helios.Retail.Models
{
    public class DistribucionInfraestructuraModel
    {

        public int idDistribucion { get; set; }

        public List<BE.distribucionInfraestructura> ListaDistribucionInfraestructuras;

        public BE.distribucionInfraestructura distribucionInfraestructuraBE;

    }
}