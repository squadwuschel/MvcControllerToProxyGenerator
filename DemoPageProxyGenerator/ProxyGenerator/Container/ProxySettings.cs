using System;
using System.Collections.Generic;

namespace ProxyGenerator.Container
{
    public class ProxySettings
    {
        #region Member
        /// <summary>
        /// Liste mit allen Templates zur Proxyerstellung
        /// </summary>
        public List<TemplateEntry> Templates { get; set; }

        /// <summary>
        /// Der Name des WebProjektes in dem sich das T4 Template befindet bzw. der Name des Ordners muss
        /// stimmen und hierbei handelt es sich meist um den gleichen Namen wie das WebProjekt.
        /// </summary>
        public string WebProjectName { get; set; }

        /// <summary>
        /// Der Ausgabepfad relativ zum WebProjekt Rootpfad in dem die Proxies erstellt werden sollen.
        /// </summary>
        public string ProxyFileOutputPath { get; set; }

        /// <summary>
        /// Gibt an ob der Name der jeweiligen Proxy Funktion mit kleinem oder großem Buchstaben beginnt. 
        /// </summary>
        public bool LowerFirstCharInFunctionName { get; set; }

        /// <summary>
        /// Der komplette Pfad bis zum WebProjekt bzw. auch Subpfade erlaubt z.B. bis zum T4 Template
        /// </summary>
        public string FullPathToTheWebProject { get; set; }

        /// <summary>
        /// Der Prefix der for den Klassennamen bei TypeLite gesetzt werden soll, wenn hier die TypeScript Interfaces zu den Klassen erstellt werden sollen
        /// Normalerweise wird hier direkt der Klassenname verwendet, ich habe aber gern ein "I" davor.
        /// </summary>
        public string TypeLiteInterfacePrefix { get; set; }

        /// <summary>
        /// Der ProxyPfad der vor jeden Service Call gestellt wird in der URL, z.B. "api"
        /// </summary>
        public string ServicePrefixUrl { get; set; }

        /// <summary>
        /// Pfad zur web.config
        /// </summary>
        public string WebConfigPath { get; set; }
        #endregion

        #region Konstruktor
        public ProxySettings()
        {
            Templates = new List<TemplateEntry>();
            WebProjectName = string.Empty;
            LowerFirstCharInFunctionName = true;
            FullPathToTheWebProject = String.Empty;
            WebConfigPath = string.Empty;
            ServicePrefixUrl = string.Empty;
        }
        #endregion
    }
}
