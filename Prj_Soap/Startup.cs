using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prj_Soap.Startup))]
namespace Prj_Soap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
