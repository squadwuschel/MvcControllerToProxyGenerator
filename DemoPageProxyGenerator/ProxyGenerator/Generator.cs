using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator
{
    public class Generator
    {
        #region Member
        private ProxySettings ProxySettings { get; set; }

        public IAngularJsProxyBuilder AngularJsProxyBuilder { get; set; }
        #endregion

        public Generator(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
            AngularJsProxyBuilder = new AngularJsProxyBuilder(ProxySettings);
        }

        public string AddAngularJsProxyGenerator()
        {
           var proxies = AngularJsProxyBuilder.BuildProxy();


           return string.Empty;
        }
    }
}
