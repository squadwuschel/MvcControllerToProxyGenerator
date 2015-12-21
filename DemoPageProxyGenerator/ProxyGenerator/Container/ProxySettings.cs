using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        #endregion

        #region Konstruktor
        public ProxySettings()
        {
            Templates = new List<TemplateEntry>();
            WebProjectName = string.Empty;
            LowerFirstCharInFunctionName = true;
            FullPathToTheWebProject = String.Empty;
        }
        #endregion
    }
}
