﻿using System.Web;
using System.Web.Mvc;

namespace PHAMVANTHANH2011064477
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
