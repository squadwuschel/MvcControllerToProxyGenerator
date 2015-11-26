using System.Collections.Generic;
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
        public IProxyGeneratorFactory Factory { get; set; }

        public IControllerManager ControllerManager { get; set; }
        #endregion

        public Generator(IProxyGeneratorFactory proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
            ControllerManager = Factory.CreateControllerManager();
        }

        public List<GeneratedProxyEntry> AddAngularJsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngularJsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateAngularJsProxyBuilder().BuildProxy(proxyControllerInfos);
            return proxies;
        }
    }
}
