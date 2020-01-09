using AutoMapper;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.AutoMapper;

namespace UrumiumMVC.IocConfig
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            var profiles =
                from t in typeof(TestAutoMapper).Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(t)
                select (Profile)Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);

            });
            For<MapperConfiguration>().Use(config);
            For<IMapper>().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));
        }
    }
}
