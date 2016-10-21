using System.Collections.Generic;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator
{
    public class Generator
    {
        #region Member
        public IProxyGeneratorFactoryManager Factory { get; set; }

        public IControllerManager ControllerManager { get; set; }

        private List<GeneratedProxyEntry> GeneratedProxyEntries { get; }
        #endregion

        public Generator(ProxySettings proxySettings)
        {
            //Wenn man das T4 Template per NuGet akualisiert, werden immer die Einstellungen 
            //die man im T4 Template vorgenommen hat überschrieben. Um dies zu verhindern,
            //kann man seine Einstellungen ebenfalls in der Web.Config ablegen und dann wird versucht
            //vorher das Property aus der Web.config auszulesen und mit dem in den ProxySettings ersetzt.
            ISettingsManager settingsManager = new SettingsManager(proxySettings);
            settingsManager.LoadSettingsFromWebConfig();
            
            Factory = new ProxyGeneratorFactoryManager(proxySettings);
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

        /// <summary>
        /// Proxy Generator für AngularJs JavaScript mit Daten füllen
        /// </summary>
        public void AddAngularJsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln für einen AngularJs Proxy
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngularJsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            //Für alle gefundenen Controller und zugehörigen Funktionen die unser PxyAttribut enthalten, die passenden Proxies erstellen.
            var proxies = Factory.CreateAngularJsProxyBuilder().BuildProxy(proxyControllerInfos);
            //Für alle gefundenen Controller die Proxies zu unserer globalen Proxyliste hinzufügen.
            GeneratedProxyEntries.AddRange(proxies);
        }

        /// <summary>
        /// Proxy Generator für AngularJs TypeScript mit Daten füllen
        /// </summary>
        public void AddAngularTsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln für einen Angular TypeScript Proxy
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngularTsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateAngularTsProxyBuilder().BuildProxy(proxyControllerInfos);
            GeneratedProxyEntries.AddRange(proxies);
        }

        public void AddAngular2TsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln für einen Angular TypeScript Proxy
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateAngular2TsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateAngular2TsProxyBuilder().BuildProxy(proxyControllerInfos);
            GeneratedProxyEntries.AddRange(proxies);
        }

        /// <summary>
        /// Proxy Generator für jQuery TypeScript mit Daten füllen
        /// </summary>
        public void AddjQueryTsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln für einen Angular TypeScript Proxy
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateJQueryTsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateJQueryTsProxyBuilder().BuildProxy(proxyControllerInfos);
            GetGeneratedProxyEntries().AddRange(proxies);
        }

        /// <summary>
        /// Proxy Generator für jQuery JavaScript mit Daten füllen
        /// </summary>
        public void AddjQueryJsProxyGenerator()
        {
            //Alle Controller und die zugehörigen Methoden zum übergebenen ProxyAttribut ermitteln für einen Angular TypeScript Proxy
            var proxyControllerInfos = ControllerManager.LoadProxyControllerInfos(typeof(CreateJQueryJsProxyAttribute), ControllerManager.GetAllProjectProxyController(Factory.GetProxySettings()));
            var proxies = Factory.CreateJQueryJsProxyBuilder().BuildProxy(proxyControllerInfos);
            GetGeneratedProxyEntries().AddRange(proxies);
        }
      
    }
}
