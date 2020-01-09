
using DataLayer.Context;
using StructureMap;
using StructureMap.Web;
using System;
using System.Threading;
using UrumiumMVC.ServiceLayer.Contract.UserInterface;

namespace UrumiumMVC.IocConfig
{
    public static class SmObjectFactory
    {


        private static readonly Lazy<Container> ContainerBuilder =
           new Lazy<Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return ContainerBuilder.Value; }
        }

        private static Container DefaultContainer()
        {
            var container = new Container(cfg =>
            {
                cfg.For<IUnitOfWork>()
                      .HybridHttpOrThreadLocalScoped()
                      .Use<ApplicationDbContext>();
                cfg.For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();

                //automapper
                cfg.AddRegistry<AutoMapperRegistry>();
                cfg.Scan(scan =>
                {
                    scan.AssemblyContainingType<IUserService>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
            return container;
        }

    }
}
