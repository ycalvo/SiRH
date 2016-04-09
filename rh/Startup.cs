using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rh.Startup))]
namespace rh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
