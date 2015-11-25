using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class AngularJsProxyBuilder : IAngularJsProxyBuilder
    {
        public ProxySettings ProxySettings { get; set; }

        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }

        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
       
        public AngularJsProxyBuilder(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
            ProxyBuilderHelper = new ProxyBuilderHelper(ProxySettings);
            ProxyBuilderHttpCall = new ProxyBuilderHttpCall(ProxySettings);

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
            var suffix = ProxySettings.Templates.First(p => p.TemplateType == TemplateTypes.AngularJsModule).TemplateSuffix;

            //TEMPLATE FÜR: "TemplateTypes.AngularJsModule":
            // function #ServiceName#($http) {{ this.http = $http; }}";
            // #PrototypeServiceCalls#";
            // angular.module('#ServiceName#', []) .service('#ServiceName#', ['$http', #ServiceName#]);";

            //TEMPLATE FÜR: "TemplateTypes.AngularJsPrototype"
            // #ServiceName#.prototype.#controllerFunctionName# = function (#serviceParamters#) {{ ";
            // return this.http.#ServiceCallAndParameters#.then(function (result) {{ return result.data; }});}}";

            //Alle controller durchgehen die übergeben wurden und für jeden dann die entsprechenden Proxy Methoden erstellen
            foreach (ProxyControllerInfo controllerInfo in proxyControllerInfos)
            {
                //Immer das passende Template ermitteln, da dieses bei jedem Durchgang ersetzt wird.
                var angularJsModuleTemplate = ProxySettings.Templates.First(p => p.TemplateType == TemplateTypes.AngularJsModule).Template;
                var prototypeFunctions = String.Empty;

                //Alle Metohden im Controller durchgehen hier sind auch nur die Methoden enthalten die das Attribut für den aktuellen ProxyTyp gesetzt wurde.
                foreach (ProxyMethodInfos methodInfos in controllerInfo.ProxyMethodInfos)
                {
                    var angularJsPrototypeTemplate = ProxySettings.Templates.First(p => p.TemplateType == TemplateTypes.AngularJsPrototype).Template;
                    string prototypeFunction = String.Empty;
                    //Den Servicenamen vor dem Prototype ersetzen.
                    prototypeFunction = angularJsPrototypeTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix));
                    //Den Methodennamen ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderHelper.GetFunctionParameters(methodInfos.MethodInfo));
                    //Service Call und Parameter ersetzen
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos));

                    prototypeFunctions += prototypeFunction;
                }

                string moduleTemplate = angularJsModuleTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix));
                moduleTemplate = moduleTemplate.Replace(ConstValuesTemplates.PrototypeServiceCalls, prototypeFunctions);

                
                GeneratedProxyEntry proxyEntry = new GeneratedProxyEntry();
                proxyEntry.FileContent = moduleTemplate;
                proxyEntry.FileName = ProxyBuilderHelper.GetProxyFileName(controllerInfo.ControllerNameWithoutSuffix, suffix, "js");
                generatedProxyEntries.Add(proxyEntry);
            }

            return generatedProxyEntries;
        }
    }
}
