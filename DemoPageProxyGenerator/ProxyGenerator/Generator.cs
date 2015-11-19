using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator
{
    public class Generator
    {
        #region Member
        private ProxySettings ProxySettings { get; set; }
        public IAngularJsProxyBuilder AngularJsProxyBuilder { get; set; }
        public IControllerManager ControllerManager { get; set; }
        #endregion

        public Generator(ProxySettings proxySettings)
        {
            ControllerManager = new ControllerManager();
            ProxySettings = proxySettings;
            AngularJsProxyBuilder = new AngularJsProxyBuilder(ProxySettings);
        }

        public string AddAngularJsProxyGenerator()
        {
            //Alle Controller ermitteln
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngularJsProxyAttribute), ControllerManager.GetAllProjectProxyController(ProxySettings));
            var proxies = AngularJsProxyBuilder.BuildProxy(proxyControllerInfos);

            return string.Empty;
        }
    }
}
