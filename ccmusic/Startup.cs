using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ccmusic.Startup))]
namespace ccmusic
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
