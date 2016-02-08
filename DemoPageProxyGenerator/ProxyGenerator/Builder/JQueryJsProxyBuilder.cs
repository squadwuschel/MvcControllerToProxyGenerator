using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class JQueryJsProxyBuilder : IProxyBuilder
    {
        #region Member
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
        public IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public JQueryJsProxyBuilder(IProxyGeneratorFactoryManager factory)
        {
            Factory = factory;
            ProxyBuilderHelper = Factory.CreateProxyBuilderHelper();
            ProxyBuilderHttpCall = Factory.CreateProxyBuilderHttpCall();
        }
        #endregion

        /// <summary>
        /// Den Proxy für AngularJs bauen. Hier wird eine Liste aus den Dateinamen (Controllern) und den enthaltenen Proxyfunktionen erstellt.
        /// </summary>
        public List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos)
        {
            CheckRequirements();

            List<GeneratedProxyEntry> generatedProxyEntries = new List<GeneratedProxyEntry>();
            var suffix = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryJsModule).TemplateSuffix;

            #region Template Example
            //TEMPLATE FÜR: "TemplateTypes.jQueryJsModule":
            // window.#ServiceName# = function() { }
            // #PrototypeServiceCalls#";

            //TEMPLATE FÜR: "TemplateTypes.jQueryJsPrototype"
            // #ServiceName#.prototype.#controllerFunctionName# = function (#serviceParamters#) {{ ";
            // return jQuery.#ServiceCallAndParameters#.then(function (result) {{ return result; }});}}";
            #endregion

            //Alle controller durchgehen die übergeben wurden und für jeden dann die entsprechenden Proxy Methoden erstellen
            foreach (ProxyControllerInfo controllerInfo in proxyControllerInfos)
            {
                //Immer das passende Template ermitteln, da dieses bei jedem Durchgang ersetzt wird.
                var angularJsModuleTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryJsModule).Template;
                var prototypeFunctions = String.Empty;

                //Alle Metohden im Controller durchgehen hier sind auch nur die Methoden enthalten die das Attribut für den aktuellen ProxyTyp gesetzt wurde.
                foreach (ProxyMethodInfos methodInfos in controllerInfo.ProxyMethodInfos)
                {
                    var angularJsPrototypeTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryJsPrototype).Template;
                    //Den Servicenamen vor dem Prototype ersetzen.
                    string prototypeFunction = angularJsPrototypeTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix));
                    //Den Methodennamen ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderHelper.GetFunctionParameters(methodInfos.MethodInfo));
                    //Service Call und Parameter ersetzen
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos));
                    //Der Variablen für Alle Prototype functions die "neue" Funktion hinzufügen.
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

        /// <summary>
        /// Funktion die überprüft ob die Vorraussetzungen erfüllt sind um den Proxy für AngularJs zu erstellen.
        /// </summary>
        private void CheckRequirements()
        {
            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryJsModule))
            {
                throw new Exception("Please add the 'jQueryJsModule' Template when you want to create a AngularJs Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryJsPrototype))
            {
                throw new Exception("Please add the 'jQueryJsPrototype' Template when you want to create a AngularJs Proxy");
            }
        }
    }
}
