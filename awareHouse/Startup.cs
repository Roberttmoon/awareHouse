using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(awareHouse.Startup))]
namespace awareHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
