﻿using System.Web;
using System.Web.Mvc;

namespace ZeroHunger42915
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}