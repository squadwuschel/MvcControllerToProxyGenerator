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

        private List<GeneratedProxyEntry> GeneratedProxyEntries { get; }
        #endregion

        public Generator(IProxyGeneratorFactory proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
            ControllerManager = Factory.CreateControllerManager();
            GeneratedProxyEntries = new List<GeneratedProxyEntry>();
        }

        /// <summary>
        /// Gibt alle erstellten Proxyeinträge zurück.
        /// </summary>
        /// <returns></returns>
        public List<GeneratedProxyEntry> GetGeneratedProxyEntries()
        {
            return GeneratedProxyEntries;
        }

        public void AddAngularJsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngularJsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateAngularJsProxyBuilder().BuildProxy(proxyControllerInfos);
            GeneratedProxyEntries.AddRange(proxies);
        }
    }
}
