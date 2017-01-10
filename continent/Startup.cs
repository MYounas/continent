using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(continent.Startup))]
namespace continent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
