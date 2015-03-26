using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentCatalogFresh.Startup))]
namespace StudentCatalogFresh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
