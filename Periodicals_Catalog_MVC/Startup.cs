using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Periodicals_Catalog_MVC.Startup))]
namespace Periodicals_Catalog_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
