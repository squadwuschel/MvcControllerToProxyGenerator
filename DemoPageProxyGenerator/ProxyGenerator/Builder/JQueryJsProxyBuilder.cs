﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Enums;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class JQueryJsProxyBuilder : IProxyBuilder
    {
        #region Member
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
        public IProxyGeneratorFactoryManager Factory { get; set; }
        public ISettingsManager SettingsManager { get; set; }
        #endregion

        #region Konstruktor
        public JQueryJsProxyBuilder(IProxyGeneratorFactoryManager factory)
        {
            Factory = factory;
            ProxyBuilderHelper = Factory.CreateProxyBuilderHelper();
            ProxyBuilderHttpCall = Factory.CreateProxyBuilderHttpCall();
            SettingsManager = Factory.CreateSettingsManager();
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

            //TEMPLATE FÜR: Window.location.href
            //#ServiceName#.prototype.#ControllerFunctionName# = function (#ServiceParamters#) { \r\n    window.location.href = #ServiceCallAndParameters# }
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

                    //Wenn es sich um eine Funktion mit HREF handelt, dann muss ein anderes Template geladen werden.
                    if (methodInfos.CreateWindowLocationHrefLink)
                    {
                        prototypeFunctions += this.BuildHrefTemplate(methodInfos, controllerInfo, suffix);
                        continue;
                    }

                    //Den Servicenamen vor dem Prototype ersetzen.
                    string prototypeFunction = angularJsPrototypeTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix, Factory.GetProxySettings().LowerFirstCharInFunctionName));
                    //Den Methodennamen ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderHelper.GetFunctionParameters(methodInfos.MethodInfo));
                    //Wenn es sich um einen FileUpload handelt wird hier das passende FormData eingebaut.
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.FunctionContent, ProxyBuilderHelper.GetFileUploadFormData(methodInfos));
                    //Service Call und Parameter ersetzen
                    prototypeFunction = prototypeFunction.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos, ProxyBuilder.jQueryJavaScript));
                    //Der Variablen für Alle Prototype functions die "neue" Funktion hinzufügen.
                    prototypeFunctions += prototypeFunction;
                }

                string moduleTemplate = angularJsModuleTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix, Factory.GetProxySettings().LowerFirstCharInFunctionName));
                moduleTemplate = moduleTemplate.Replace(ConstValuesTemplates.PrototypeServiceCalls, prototypeFunctions);


                GeneratedProxyEntry proxyEntry = new GeneratedProxyEntry();
                proxyEntry.FileContent = moduleTemplate;
                proxyEntry.FileName = ProxyBuilderHelper.GetProxyFileName(controllerInfo.ControllerNameWithoutSuffix, suffix, "js");
                proxyEntry.FilePath = SettingsManager.GetAlternateOutputpath(TemplateTypes.jQueryJsModule);
                generatedProxyEntries.Add(proxyEntry);
            }

            return generatedProxyEntries;
        }

        /// <summary>
        /// Das passende HREF Template laden und die passenden TemplateString ersetzten.
        /// </summary>
        private string BuildHrefTemplate(ProxyMethodInfos methodInfos, ProxyControllerInfo controllerInfo, string suffix)
        {
            var functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.AngularJsWindowLocationHref).Template;

            //Den Methodennamen ersetzen - Der Servicename der aufgerufen werden soll.
            string functionCall = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
            //Parameter des Funktionsaufrufs ersetzen.
            functionCall = functionCall.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderHelper.GetFunctionParameters(methodInfos.MethodInfo));
            //Href Call zusammenbauen und Parameter ersetzen
            functionCall = functionCall.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHrefLink(methodInfos, ProxyBuilder.AngularJavaScript));
            //Den Servicenamen vor dem Prototype ersetzen.
            functionCall = functionCall.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix, Factory.GetProxySettings().LowerFirstCharInFunctionName));
            return functionCall;
        }

        /// <summary>
        /// Funktion die überprüft ob die Vorraussetzungen erfüllt sind um den Proxy für AngularJs zu erstellen.
        /// </summary>
        private void CheckRequirements()
        {
            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryJsModule))
            {
                throw new Exception("Please add the 'jQueryJsModule' Template when you want to create a jQuery Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryJsPrototype))
            {
                throw new Exception("Please add the 'jQueryJsPrototype' Template when you want to create a jQuery Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.jQueryJsWindowLocationHref))
            {
                throw new Exception("Please add the 'jQueryJsWindowLocationHref' Template when you want to create a jQuery Proxy");
            }
        }
    }
}
