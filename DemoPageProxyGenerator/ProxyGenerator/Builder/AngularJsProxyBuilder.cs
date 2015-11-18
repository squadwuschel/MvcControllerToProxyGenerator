using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;

namespace ProxyGenerator.Builder
{
    public class AngularJsProxyBuilder : IAngularJsProxyBuilder
    {
        public ProxySettings ProxySettings { get; set; }
        public IAssemblyManager AssemblyManager { get; set; }
        public IControllerManager ControllerManager { get; set; }

        public AngularJsProxyBuilder(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
            AssemblyManager = new AssemblyManager();
            ControllerManager = new ControllerManager();

            if (proxySettings.Templates.All(p => p.TemplateType != TemplateTypes.AngularJsModule))
            {
                throw  new Exception("Please add the 'AngularJsModule' Template when you want to create a AngularJs Proxy");
            }

            if (proxySettings.Templates.All(p => p.TemplateType != TemplateTypes.AngularJsPrototype))
            {
                throw new Exception("Please add the 'AngularJsPrototype' Template when you want to create a AngularJs Proxy");
            }
        }

        /// <summary>
        /// Den Proxy für AngularJs bauen. Hier wird eine Liste aus den Dateinamen (Controllern) und den enthaltenen Proxyfunktionen erstellt.
        /// </summary>
        public List<GeneratedProxyEntry> BuildProxy()
        {
            List<GeneratedProxyEntry> proxyEntries = new List<GeneratedProxyEntry>();

            var assemblies = AssemblyManager.LoadAssemblies(ProxySettings.WebProjectName, ProxySettings.FullPathToTheWebProject);
            var controller = ControllerManager.GetAllProxyController(assemblies);




            return proxyEntries;
        }
    }
}
