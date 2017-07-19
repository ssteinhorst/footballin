using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Footballin.Startup))]
namespace Footballin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
