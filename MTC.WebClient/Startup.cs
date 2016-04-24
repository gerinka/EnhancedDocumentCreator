using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mtc.WebClient.Startup))]
namespace Mtc.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
