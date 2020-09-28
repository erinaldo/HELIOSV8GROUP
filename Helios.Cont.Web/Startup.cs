using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helios.Cont.Web.App_Start.Startup))]
namespace Helios.Cont.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}