using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestaoCompras.Startup))]
namespace GestaoCompras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
