using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrustAnalytics.Startup))]
namespace TrustAnalytics
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
