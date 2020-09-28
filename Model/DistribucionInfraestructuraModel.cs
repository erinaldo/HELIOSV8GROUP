using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = Helios.Cont.Business.Entity;

namespace Model
{
    public class DistribucionInfraestructuraModel
    {

        public int idDistribucion { get; set; }

        public List<BE.distribucionInfraestructura> ListaDistribucionInfraestructuras;

        public BE.distribucionInfraestructura distribucionInfraestructuraBE;

    }
}
