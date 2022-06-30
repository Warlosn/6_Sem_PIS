using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcIdentityLab.Startup))]
namespace MvcIdentityLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
