using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobsPortal.Startup))]
namespace JobsPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
