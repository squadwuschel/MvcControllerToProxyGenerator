using System;
using System.Collections.Generic;
using System.Linq;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class AngularTsProxyBuilder : IProxyBuilder
    {
        #region Member
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        public IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }
        public IProxyBuilderDataTypeHelper ProxyBuilderTypeHelper { get; set; }
        public IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public AngularTsProxyBuilder(IProxyGeneratorFactoryManager factory)
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
            var suffix = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.AngularTsModule).TemplateSuffix;

            #region Template Example
            //TEMPLATE FÜR: "TemplateTypes.AngularTsModule":
            // module App.Services {; 
            // export interface I#ServiceName# { #InterfaceDefinitions# }; 
            // export class #ServiceName# implements I#ServiceName# {{; 
            //     static $inject = ['$http'];
            //     constructor(private $http: ng.IHttpService) { }; 
            //
            //  #ServiceFunctions#; 
            //
            //#region Angular Module Definition  
            // private static _module: ng.IModule;
            // public static get module(): ng.IModule {
            //     if (this._module) { return this._module; }
            //     this._module = angular.module('#ServiceName#', []); 
            //     this._module.service('#ServiceName#', #ServiceName#);
            //    return this._module;}
            //#endregion 

            //TEMPLATE FÜR: "TemplateTypes.AngularTsAjaxCallWithReturnType"
            // #ControllerFunctionName#(#ServiceParamters#) : ng.IPromise<{#ControllerFunctionReturnType#}> {
            // "#FunctionContent#"
            // return this.$http.#ServiceCallAndParameters#.then(
            //    (response: ng.IHttpPromiseCallbackArg<{#ControllerFunctionReturnType#}>) : {#ControllerFunctionReturnType#} => { return response.data; } ); }

            //TEMPLATE FÜR: "TemplateTypes.AngularTsAjaxCallNoReturnType"
            // #ControllerFunctionName#(#ServiceParamters#) : void  { \r\n this.$http.#ServiceCallAndParameters#;}
            #endregion

            //Alle controller durchgehen die übergeben wurden und für jeden dann die entsprechenden Proxy Methoden erstellen
            foreach (ProxyControllerInfo controllerInfo in proxyControllerInfos)
            {
                //Immer das passende Template ermitteln, da dieses bei jedem Durchgang ersetzt wird.
                var angularTsModuleTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.AngularTsModule).Template;
                var ajaxCalls = String.Empty;
                var serviceInterfaceDefinitions = string.Empty;

                //Alle Metohden im Controller durchgehen hier sind auch nur die Methoden enthalten die das Attribut für den aktuellen ProxyTyp gesetzt wurde.
                foreach (ProxyMethodInfos methodInfos in controllerInfo.ProxyMethodInfos)
                {
                    var functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.AngularTsAjaxCallNoReturnType).Template;
                    //sollte ein ReturnType verwendet werden, dann das andere Template laden mit ReturnType
                    
                    if (ProxyBuilderTypeHelper.HasReturnType(methodInfos.ReturnType))
                    {
                        functionTemplate = Factory.GetProxySettings().Templates.First(p => p.TemplateType == TemplateTypes.AngularTsAjaxCallWithReturnType).Template;
                        //Für Methoden mit ReturnType muss auch der passende ReturnType ersetzt werden
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionReturnType, ProxyBuilderTypeHelper.GetTsType(methodInfos.ReturnType));
                        //Die Servicedefinition für jede Methode hinzufügen
                        serviceInterfaceDefinitions += String.Format("    {0}({1}) : ng.IPromise<{2}>;\r\n", ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name),
                                                                                                         ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo),
                                                                                                         ProxyBuilderTypeHelper.GetTsType(methodInfos.ReturnType));
                        //Wenn es sich um einen FileUpload handelt wird hier das passende FormData eingebaut.
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.FunctionContent, ProxyBuilderHelper.GetFileUploadFormData(methodInfos));
                    }
                    else
                    {
                        //Für Funktionen Ohne Rückgabewert "void" setzten
                        serviceInterfaceDefinitions += String.Format("    {0}({1}): void;\r\n", ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name), 
                                                                                            ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
                        functionTemplate = functionTemplate.Replace(ConstValuesTemplates.FunctionContent, ProxyBuilderHelper.GetFileUploadFormData(methodInfos));
                    }

                    //Den Methodennamen ersetzen - Der Servicename der aufgerufen werden soll.
                    string functionCall = functionTemplate.Replace(ConstValuesTemplates.ControllerFunctionName, ProxyBuilderHelper.GetProxyFunctionName(methodInfos.MethodInfo.Name));
                    //Parameter des Funktionsaufrufs ersetzen.
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceParamters, ProxyBuilderTypeHelper.GetFunctionParametersWithType(methodInfos.MethodInfo));
                    //Service Call und Parameter ersetzen
                    functionCall = functionCall.Replace(ConstValuesTemplates.ServiceCallAndParameters, ProxyBuilderHttpCall.BuildHttpCall(methodInfos));
                    ajaxCalls += functionCall;
                }

                string moduleTemplate = angularTsModuleTemplate.Replace(ConstValuesTemplates.ServiceName, ProxyBuilderHelper.GetServiceName(controllerInfo.ControllerNameWithoutSuffix, suffix, false));
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
            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.AngularTsModule))
            {
                throw new Exception("Please add the 'AngularTsModule' Template when you want to create a AngularTs Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.AngularTsAjaxCallWithReturnType))
            {
                throw new Exception("Please add the 'AngularTsAjaxCallWithReturnType' Template when you want to create a AngularTs Proxy");
            }

            if (Factory.GetProxySettings().Templates.All(p => p.TemplateType != TemplateTypes.AngularTsAjaxCallNoReturnType))
            {
                throw new Exception("Please add the 'AngularTsAjaxCallNoReturnType' Template when you want to create a AngularTs Proxy");
            }
        }
    }
}
