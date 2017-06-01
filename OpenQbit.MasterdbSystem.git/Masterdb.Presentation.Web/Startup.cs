using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Masterdb.Presentation.Web.Startup))]
namespace Masterdb.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
