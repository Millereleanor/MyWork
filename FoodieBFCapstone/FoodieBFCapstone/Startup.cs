using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodieBFCapstone.Startup))]
namespace FoodieBFCapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
