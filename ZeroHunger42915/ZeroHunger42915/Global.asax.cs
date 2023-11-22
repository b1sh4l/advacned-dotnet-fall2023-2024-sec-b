using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ZeroHunger42915
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.EmployeeDTO, Models.Employee>();
            });

            var mapper = config.CreateMapper();
            HttpContext.Current.Application["Mapper"] = mapper;

        }
    }
}
