using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampingWebForms.Startup))]
namespace CampingWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
