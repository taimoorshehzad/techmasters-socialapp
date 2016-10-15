using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialApp.Startup))]
namespace SocialApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
