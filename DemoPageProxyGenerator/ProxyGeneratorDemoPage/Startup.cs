using Microsoft.Owin;
using Owin;
using ProxyGeneratorDemoPage;

[assembly: OwinStartup(typeof(Startup))]
namespace ProxyGeneratorDemoPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
