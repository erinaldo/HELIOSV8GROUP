﻿using System.Web;
using System.Web.Mvc;

namespace Helios.Cont.Presentation.MvcProj
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
