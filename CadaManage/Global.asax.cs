using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CadaManage.Models;

namespace CadaManage
{
    //public class MvcApplication : System.Web.HttpApplication
    public class MvcApplication: HttpApplication {
        private static readonly ILog logger = LogManager.GetLogger("MyLogger");
        protected void Application_Start(){
            logger.Info("Application Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        override public void Init(){
            logger.Info("Application Init");
        }
        override public void Dispose(){
            logger.Info("Application Dispose");
        }
        protected void Application_Error(){
            logger.Info("Application Error");
            logger.Error("Application Error");
        }
        protected void Application_End(){
            logger.Info("Application End");
        }
    }
}
