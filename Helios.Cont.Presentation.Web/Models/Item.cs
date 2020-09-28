using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Presentation.Web.Models
{
    public class Item
    {
        public int CategoryId { get; set; }
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductUnit { get; set; }
        

    }
}