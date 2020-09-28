using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Web.Models
{
    public class ProductModel
    {
        public List<detalleitems> Detalleitems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
    }
}