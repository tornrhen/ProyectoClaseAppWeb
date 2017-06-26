using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoSoft2.Startup))]
namespace ProyectoSoft2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
