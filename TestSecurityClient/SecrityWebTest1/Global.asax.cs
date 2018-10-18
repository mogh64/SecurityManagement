using ISE.Framework.Client.Common.Environment;
using ISE.Framework.Client.Web.Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecrityWebTest1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetEnvironment();
        }
        private void SetEnvironment()
        {
            EnvironmentVariables.CurrentEnvironment = EnvironmentType.Web;
            EnvironmentVariables.RegisterViewer(new IseWebBussinessExceptionViewer(), EnvironmentVariables.CurrentEnvironment);
        }
    }
}
