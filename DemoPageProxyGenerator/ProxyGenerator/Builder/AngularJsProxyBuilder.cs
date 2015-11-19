using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Builder
{
    public class AngularJsProxyBuilder : IAngularJsProxyBuilder
    {
        public ProxySettings ProxySettings { get; set; }
       
        public AngularJsProxyBuilder(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;

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
        public List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos)
        {
            List<GeneratedProxyEntry> generatedProxyEntries = new List<GeneratedProxyEntry>();

            //Template für "TemplateTypes.AngularJsModule":
            // function #ServiceName#($http) {{ this.http = $http; }}";
            // #PrototypeServiceCalls#";
            // angular.module('#ServiceName#', []) .service('#ServiceName#', ['$http', #ServiceName#]);";

            //Template für "TemplateTypes.AngularJsPrototype"
            // #ServiceName#.prototype.#controllerFunctionName# = function (#serviceParamters#) {{ ";
            // return this.http.#ServiceCallAndParameters#.then(function (result) {{ return result.data; }});}}";


            foreach (GeneratedProxyEntry proxyEntry in generatedProxyEntries)
            {
               
                
                 
            }


            return generatedProxyEntries;
        }
    }
}
