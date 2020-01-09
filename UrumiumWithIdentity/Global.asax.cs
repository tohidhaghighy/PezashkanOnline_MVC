using DataLayer.Context;
using DataLayer.Migration;
using IdentitySample.Models;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UrumiumMVC.IocConfig;
using UrumiumWithIdentity;
using StructureMap;

namespace IdentitySample
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetDbInitializer();

        }

        public class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                if (controllerType == null)
                {

                    throw new InvalidOperationException(string.Format("Page not found:", requestContext.HttpContext.Request.RawUrl));
                }

                return SmObjectFactory.Container.GetInstance(controllerType) as Controller;
            }
        }

        private static void SetDbInitializer()
        {
            //Database.SetInitializer<ShopDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            SmObjectFactory.Container.GetInstance<IUnitOfWork>().ForceDatabaseInitialize();
        }

    }
}
