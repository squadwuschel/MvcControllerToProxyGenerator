using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoPageProxyGenerator.Startup))]
namespace DemoPageProxyGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
