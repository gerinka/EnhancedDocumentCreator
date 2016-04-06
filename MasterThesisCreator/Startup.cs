using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterThesisCreator.Startup))]
namespace MasterThesisCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
