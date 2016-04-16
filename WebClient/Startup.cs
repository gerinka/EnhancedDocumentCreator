using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MTC.WebClient.Startup))]
namespace MTC.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
