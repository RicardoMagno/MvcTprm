using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTprm.Startup))]
namespace MvcTprm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
