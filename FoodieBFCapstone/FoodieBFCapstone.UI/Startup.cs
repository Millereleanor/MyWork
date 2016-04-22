using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodieBFCapstone.UI.Startup))]
namespace FoodieBFCapstone.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
