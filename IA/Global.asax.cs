using System.Web.Mvc;
using System.Web.Routing;
using IA.App_Start;
using System.Web.Optimization;
using System.Web.Http;
using System.Data.Entity;
using IA.Models;
using IA.Migrations;
using System;
using System.Data.Entity.Migrations;

namespace IA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseStore, Configuration>());
        }
    }
}
