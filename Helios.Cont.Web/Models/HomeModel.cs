using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helios.Cont.Web.Models
{
    public class HomeModel
    {
        public WebReport WebReport { get; set; }
        public string[] ReportsList { get; set; }
    }
}