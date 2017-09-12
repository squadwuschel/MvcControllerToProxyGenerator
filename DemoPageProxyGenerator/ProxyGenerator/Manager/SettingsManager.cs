using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using ProxyGenerator.Container;
using ProxyGenerator.Enums;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class SettingsManager : ISettingsManager
    {
        public ProxySettings ProxySettings { get; set; }

        public SettingsManager(ProxySettings settings)
        {
            ProxySettings = settings;
        }

        /// <summary>
        /// Laden der Einstellungen aus der Web.Config. Nur wenn die Einstellungen dort existieren
        /// </summary>
        public void LoadSettingsFromWebConfig()
        {
            try
            {
                var map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = ProxySettings.WebConfigPath;
                var configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                var allSettings = configFile.AppSettings.Settings;

                if (allSettings.AllKeys.Contains("ProxyGenerator_WebProjectName"))
                {
                    ProxySettings.WebProjectName = allSettings["ProxyGenerator_WebProjectName"].Value;
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_ProxyFileOutputPath"))
                {
                    ProxySettings.ProxyFileOutputPath = allSettings["ProxyGenerator_ProxyFileOutputPath"].Value;
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_LowerFirstCharInFunctionName"))
                {
                    ProxySettings.LowerFirstCharInFunctionName = bool.Parse(allSettings["ProxyGenerator_LowerFirstCharInFunctionName"].Value);
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_TypeLiteInterfacePrefix"))
                {
                    ProxySettings.TypeLiteInterfacePrefix = allSettings["ProxyGenerator_TypeLiteInterfacePrefix"].Value;
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_ServicePrefixUrl"))
                {
                    ProxySettings.ServicePrefixUrl = allSettings["ProxyGenerator_ServicePrefixUrl"].Value;
                }

                //SUFFIX Settings
                //Das Module Template wird als "Standard" Template verwendet.

                if (allSettings.AllKeys.Contains("ProxyGenerator_TemplateSuffix_AngularJs"))
                {
                    var template = ProxySettings.Templates.FirstOrDefault(p => p.TemplateType == TemplateTypes.AngularJsModule);
                    if (template != null)
                    {
                        template.TemplateSuffix = allSettings["ProxyGenerator_TemplateSuffix_AngularJs"].Value;
                    }
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_TemplateSuffix_AngularTs"))
                {
                    var template = ProxySettings.Templates.FirstOrDefault(p => p.TemplateType == TemplateTypes.AngularTsModule);
                    if (template != null)
                    {
                        template.TemplateSuffix = allSettings["ProxyGenerator_TemplateSuffix_AngularTs"].Value;
                    }
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_TemplateSuffix_Angular2Ts"))
                {
                    var template = ProxySettings.Templates.FirstOrDefault(p => p.TemplateType == TemplateTypes.Angular2TsModule);
                    if (template != null)
                    {
                        template.TemplateSuffix = allSettings["ProxyGenerator_TemplateSuffix_Angular2Ts"].Value;
                    }
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_TemplateSuffix_jQueryJs"))
                {
                    var template = ProxySettings.Templates.FirstOrDefault(p => p.TemplateType == TemplateTypes.jQueryJsModule);
                    if (template != null)
                    {
                        template.TemplateSuffix = allSettings["ProxyGenerator_TemplateSuffix_jQueryJs"].Value;
                    }
                }

                if (allSettings.AllKeys.Contains("ProxyGenerator_TemplateSuffix_jQueryTs"))
                {
                    var template = ProxySettings.Templates.FirstOrDefault(p => p.TemplateType == TemplateTypes.jQueryTsModule);
                    if (template != null)
                    {
                        template.TemplateSuffix = allSettings["ProxyGenerator_TemplateSuffix_jQueryTs"].Value;
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error Reading Settings from Web.config | Message: " + exception.Message);
            }
        }

        /// <summary>
        /// Setzt den alternativen Ausgabepfad für die Templates im passenden Template
        /// </summary>
        /// <param name="templateType"></param>
        public string GetAlternateOutputpath(TemplateTypes templateType)
        {
            //ACHTUNG geht nur wenn: "jQueryTsModule", "jQueryJsModule", "AngularJsModule",  "Angular2TsModule" oder "AngularTsModule" übergeben werden!
            //Denn nur diese Werte gibt es in der Web.config
            //ProxyGenerator_OutputPath_jQueryTsModule
            //ProxyGenerator_OutputPath_jQueryJsModule
            //ProxyGenerator_OutputPath_AngularJsModule
            //ProxyGenerator_OutputPath_AngularTsModule
            //ProxyGenerator_OutputPath_Angular2TsModule
            var baseWebConfigStr = "ProxyGenerator_OutputPath_" + templateType.ToString();

            //Web.config auslesen
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = ProxySettings.WebConfigPath;
            var configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var allSettings = configFile.AppSettings.Settings;
            if (allSettings.AllKeys.Contains(baseWebConfigStr))
            {
                return allSettings[baseWebConfigStr].Value ?? String.Empty;
            }

            return string.Empty;
        }
    }
}
