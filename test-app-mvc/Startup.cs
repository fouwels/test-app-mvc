using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test_app_mvc.Startup))]
namespace test_app_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
