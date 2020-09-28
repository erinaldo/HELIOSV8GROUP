using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ModelGeneral
    {               

        private string _empresaID = "12345678912";  // the name field
        public string empresaID    // the Name property
        {
            get => _empresaID;
            set => _empresaID = value;
        }

        private int _establecimientoID = 3;  // the name field
        public int establecimientoID    // the Name property
        {
            get => _establecimientoID;
            set => _establecimientoID = value;
        }


    }
}
