using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(IdentitySample.Startup))]
namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
