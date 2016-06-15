using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Edc.WebClient.Startup))]
namespace Edc.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
