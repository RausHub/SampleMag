using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SampleMag.App_Start;

namespace SampleMag
{
    public class MvcApplication : HttpApplication
    {
        void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();            
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
