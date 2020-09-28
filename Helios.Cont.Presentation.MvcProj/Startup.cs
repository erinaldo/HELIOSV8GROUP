using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helios.Cont.Presentation.MvcProj.Startup))]
namespace Helios.Cont.Presentation.MvcProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
