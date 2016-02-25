using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ClientWCF.Startup))]
namespace MVC_ClientWCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
