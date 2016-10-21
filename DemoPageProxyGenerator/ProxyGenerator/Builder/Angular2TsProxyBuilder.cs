using System;
using System.Collections.Generic;
using System.Linq;
using ProxyGenerator.Container;
using ProxyGenerator.Enums;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class Angular2TsProxyBuilder : IProxyBuilder
    {
        #region Member
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
        public IProxyBuilderDataTypeHelper ProxyBuilderTypeHelper { get; set; }
        public IProxyGeneratorFactoryManager Factory { get; set; }
        public ISettingsManager SettingsManager { get; set; }
        #endregion

        #region Konstruktor
        public Angular2TsProxyBuilder(IProxyGeneratorFactoryManager factory)
        {
            Factory = factory;
            ProxyBuilderHelper = Factory.CreateProxyBuilderHelper();
            ProxyBuilderHttpCall = Factory.CreateProxyBuilderHttpCall();
            ProxyBuilderTypeHelper = Factory.CreateBuilderTypeHelper();
            SettingsManager = Factory.CreateSettingsManager();
        }
        #endregion

        public List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos)
        {
            CheckRequirements();

            List<GeneratedProxyEntry> generatedProxyEntries = new List<GeneratedProxyEntry>();
            var suffix = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.Angular2TsModule).TemplateSuffix;

            #region Template Example
            //TEMPLATE FÜR: "TemplateTypes.Angular2TsModule":
            //import {Injectable} from '@angular/core';\r\n
            //import {Http, Response} from '@angular/http';\r\n
            //import {Observable} from 'rxjs/observable';\r\n"
            //import 'rxjs/add/operator/map';\r\n\r\n"
            //
            //@Injectable()\r\n
            //export class #ServiceName# {
            //   constructor(private _http: Http) {\r\n\r\n
            //      #ServiceFunctions#
            //\r\n }

            //TEMPLATE FÜR: "TemplateTypes.Angular2TsModuleObservableWithReturnType"
            //public #ControllerFunctionName#(#ServiceParamters#) : Observable<{#ControllerFunctionReturnType#}> { \r\n #FunctionContent#"  +
            //    return this._http.#ServiceCallAndParameters#.map((response: Response)  => <{#ControllerFunctionReturnType#}>response.json() as {#ControllerFunctionReturnType#});\r\n} \r\n\r\n";

            //TEMPLATE FÜR: "TemplateTypes.Angular2TsModuleObservableNoReturnType"
            //  public #ControllerFunctionName#(#ServiceParamters#) : void  { \r\n  #FunctionContent#  this._http.#ServiceCallAndParameters#; \r\n } \r\n\r\n";

            //TEMPLATE FÜR: Window.location.href
            // public #ControllerFunctionName#(#ServiceParamters#) : void  { \r\n  window.location.href = #ServiceCallAndParameters#; };
            #endregion

            //Alle controller durchgehen die übergeben wurden und für jeden dann die entsprechenden Proxy Methoden erstellen
            foreach (ProxyControllerInfo controllerInfo in proxyControllerInfos)
            {
                //Immer das passende Template ermitteln, da dieses bei jedem Durchgang ersetzt wird.
                var angularTsModuleTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.Angular2TsModule).Template;
                var ajaxCalls = String.Empty;

                //Alle Metohden im Controller durchgehen hier sind auch nur die Methoden enthalten die das Attribut für den aktuellen ProxyTyp gesetzt wurde.
                foreach (ProxyMethodInfos methodInfos in controllerInfo.ProxyMethodInfos)
                {
                    var functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.Angular2TsModuleObservableNoReturnType).Template;

                    //Wenn es sich um eine Funktion mit HREF handelt, dann muss ein anderes Template geladen werden.
                    if (methodInfos.CreateWindowLocationHrefLink)
                    {
                        ajaxCalls += this.BuildHrefTemplate(methodInfos);
                        //Da ein HREF Link auch keinen Rückgabewert hat, diesen mit Void ersetzen und die passende Interface Definition erstellen.
                        continue;
                    }

                    if (ProxyBuilderTypeHelper.HasReturnType(methodInfos.ReturnType))
                    {
                        //sollte ein ReturnType verwendet werden, dann das andere Template laden mit ReturnType
                        functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.Angular2TsModuleObservableWithReturnType).Template;
                        //Für Methoden mit ReturnType muss auch der passende ReturnType ersetzt werden
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionReturnType, ProxyBuilderTypeHelper.GetTsType(methodInfos.ReturnType));
                        //Wenn es sich um einen FileUpload handelt wird hier das passende FormData eingebaut.
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.FunctionContent, ProxyBuilderHelper.GetFileUploadFormData(methodInfos));
                    }
                    else
                    {
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.FunctionContent, ProxyBuilderHelper.GetFileUploadFormData(methodInfos));
                    }

                    //Den Methodennamen ersetzen - Der Servicename der aufgerufen werden soll.
                    string functionCall = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
                    //Service Call und Parameter ersetzen
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos, ProxyBuilder.AngularTypeScript));
                    ajaxCalls += functionCall;
                }

                string moduleTemplate = angularTsModuleTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix.TrimStart('.'), false));
                moduleTemplate = moduleTemplate.Replace(ConstValuesTemplates.ServiceFunctions, ajaxCalls);

                GeneratedProxyEntry proxyEntry = new GeneratedProxyEntry();
                proxyEntry.FileContent = moduleTemplate;
                proxyEntry.FileName = ProxyBuilderHelper.GetProxyFileName(controllerInfo.ControllerNameWithoutSuffix, suffix, "ts");
                proxyEntry.FilePath = SettingsManager.GetAlternateOutputpath(TemplateTypes.Angular2TsModule);
                generatedProxyEntries.Add(proxyEntry);
            }

            return generatedProxyEntries;
        }

        /// <summary>
        /// Das passende HREF Template laden und die passenden TemplateString ersetzten.
        /// </summary>
        private string BuildHrefTemplate(ProxyMethodInfos methodInfos)
        {
            var functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.Angular2TsWindowLocationHref).Template;

            //Den Methodennamen ersetzen - Der Servicename der aufgerufen werden soll.
            string functionCall = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
            //Parameter des Funktionsaufrufs ersetzen.
            functionCall = functionCall.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
            //Href Call zusammenbauen und Parameter ersetzen
            functionCall = functionCall.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHrefLink(methodInfos, ProxyBuilder.AngularTypeScript));
            return functionCall;
        }

        /// <summary>
        /// Funktion die überprüft ob die Vorraussetzungen erfüllt sind um den Proxy für AngularJs zu erstellen.
        /// </summary>
        private void CheckRequirements()
        {
            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.Angular2TsModule))
            {
                throw new Exception("Please add the 'Angular2TsModule' Template when you want to create a Angular2Ts Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.Angular2TsModuleObservableWithReturnType))
            {
                throw new Exception("Please add the 'Angular2TsModuleObservableWithReturnType' Template when you want to create a Angular2Ts Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.Angular2TsModuleObservableNoReturnType))
            {
                throw new Exception("Please add the 'Angular2TsModuleObservableNoReturnType' Template when you want to create a Angular2Ts Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.Angular2TsWindowLocationHref))
            {
                throw new Exception("Please add the 'Angular2TsWindowLocationHref' Template when you want to create a Angular2Ts Proxy");
            }
        }
    }
}
