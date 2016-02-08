using System;
using System.Collections.Generic;
using System.Linq;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class JQueryTsProxyBuilder : IProxyBuilder
    {
        #region Member
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        public IProxyBuilderDataTypeHelper ProxyBuilderTypeHelper { get; set; }
        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
        public IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public JQueryTsProxyBuilder(IProxyGeneratorFactoryManager factory)
        {
            Factory = factory;
            ProxyBuilderHelper = Factory.CreateProxyBuilderHelper();
            ProxyBuilderHttpCall = Factory.CreateProxyBuilderHttpCall();
            ProxyBuilderTypeHelper = Factory.CreateBuilderTypeHelper();
        }
        #endregion

        public List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos)
        {
            CheckRequirements();
            List<GeneratedProxyEntry> generatedProxyEntries = new List<GeneratedProxyEntry>();
            var suffix = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryTsModule).TemplateSuffix;

            #region Template Example
            //TEMPLATE FÜR: "TemplateTypes.jQueryTsModule":
            // module App.JqueryServices { 
            // export interface I#ServiceName# { #InterfaceDefinitions# }
            // export class #ServiceName# implements I#ServiceName# {
            //  "#ServiceFunctions# \r\n  } }

            //TEMPLATE FÜR: "TemplateTypes.jQueryTsAjaxCallWithReturnType"
            // public #ControllerFunctionName#(#ServiceParamters#) : JQueryPromise<{#ControllerFunctionReturnType#}> {
            // return this.$http.#ServiceCallAndParameters#.then(
            //     return jQuery.#ServiceCallAndParameters#.then((result: JQueryPromiseCallback<{#ControllerFunctionReturnType#}>) : {#ControllerFunctionReturnType#} => { return result; });\r\n}

            //TEMPLATE FÜR: "TemplateTypes.jQueryTsAjaxCallNoReturnType"
            // public #ControllerFunctionName#(#ServiceParamters#) : void { jQuery.#ServiceCallAndParameters# \r\n}
            #endregion

            //Alle controller durchgehen die übergeben wurden und für jeden dann die entsprechenden Proxy Methoden erstellen
            foreach (ProxyControllerInfo controllerInfo in proxyControllerInfos)
            {
                //Immer das passende Template ermitteln, da dieses bei jedem Durchgang ersetzt wird.
                var jQueryTsModuleTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryTsModule).Template;
                var ajaxCalls = String.Empty;
                var serviceInterfaceDefinitions = string.Empty;

                //Alle Metohden im Controller durchgehen hier sind auch nur die Methoden enthalten die das Attribut für den aktuellen ProxyTyp gesetzt wurde.
                foreach (ProxyMethodInfos methodInfos in controllerInfo.ProxyMethodInfos)
                {
                    var functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryTsAjaxCallNoReturnType).Template;
                    //sollte ein ReturnType verwendet werden, dann das andere Template laden mit ReturnType
                    if (ProxyBuilderTypeHelper.HasReturnType(methodInfos.ReturnType))
                    {
                        functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.jQueryTsAjaxCallWithReturnType).Template;
                        //Für Methoden mit ReturnType muss auch der passende ReturnType ersetzt werden
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionReturnType, ProxyBuilderTypeHelper.GetTsType(methodInfos.ReturnType));

                        //Die Servicedefinition für jede Methode hinzufügen
                        serviceInterfaceDefinitions += String.Format("    {0}({1}) : JQueryPromise<{2}>;\r\n", ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name),
                                                                                                         ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo),
                                                                                                         ProxyBuilderTypeHelper.GetTsType(methodInfos.ReturnType));
                    }
                    else
                    {
                        //Für Funktionen Ohne Rückgabewert "void" setzten
                        serviceInterfaceDefinitions += String.Format("    {0}({1}): void;\r\n", ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name),
                                                                                            ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
                    }

                    //Den Methodennamen ersetzen - Der Servicename der aufgerufen werden soll.
                    string functionCall = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
                    //Service Call und Parameter ersetzen
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos));
                    ajaxCalls += functionCall;
                }

                string moduleTemplate = jQueryTsModuleTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix));
                moduleTemplate = moduleTemplate.Replace(ConstValuesTemplates.ServiceFunctions, ajaxCalls);
                moduleTemplate = moduleTemplate.Replace(ConstValuesTemplates.InterfaceDefinitions, serviceInterfaceDefinitions);

                GeneratedProxyEntry proxyEntry = new GeneratedProxyEntry();
                proxyEntry.FileContent = moduleTemplate;
                proxyEntry.FileName = ProxyBuilderHelper.GetProxyFileName(controllerInfo.ControllerNameWithoutSuffix, suffix, "ts");
                generatedProxyEntries.Add(proxyEntry);
            }

            return generatedProxyEntries;
        }

        /// <summary>
        /// Funktion die überprüft ob die Vorraussetzungen erfüllt sind um den Proxy für AngularJs zu erstellen.
        /// </summary>
        private void CheckRequirements()
        {
            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryTsModule))
            {
                throw new Exception(
                    "Please add the 'jQueryTsModule' Template when you want to create a jQuery Proxy");
            }

            if (
                Factory.GetProxySettings()
                    .Templates.All(p => p.TemplateType != TemplateTypes.jQueryTsAjaxCallWithReturnType))
            {
                throw new Exception(
                    "Please add the 'jQueryTsAjaxCallWithReturnType' Template when you want to create a jQuery Proxy");
            }

            if (
                Factory.GetProxySettings()
                    .Templates.All(p => p.TemplateType != TemplateTypes.jQueryTsAjaxCallNoReturnType))
            {
                throw new Exception(
                    "Please add the 'jQueryTsAjaxCallNoReturnType' Template when you want to create a jQuery Proxy");
            }
        }
    }
}
