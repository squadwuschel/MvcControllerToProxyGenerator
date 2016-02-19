using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProxyGenerator.Container
{
    public class ProxyMethodInfos
    {
        #region Member
        /// <summary>
        /// Der aktuelle Namespace der Methode
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Der Methodenname inkl. Namespace davor.
        /// </summary>
        public string MethodNameWithNamespace { get; set; }

        /// <summary>
        /// Dem Proxy Attribut kann man einen Returntype hinterlegen, dieser wird hier zurückgegeben
        /// </summary>
        public Type ReturnType { get; set; }

        /// <summary>
        /// Reflexion Type für die Methode
        /// </summary>
        public MethodInfo MethodInfo { get; set; }

        /// <summary>
        /// Der zugehörige Controller zur Methode
        /// </summary>
        public Type Controller { get; set; }

        /// <summary>
        /// Die Parameter der Methode die übergeben werden in der richtigen Reihenfolge.
        /// </summary>
        public List<ProxyMethodParameterInfo> ProxyMethodParameterInfos { get; set; }
        #endregion

        #region Konstruktor
        public ProxyMethodInfos()
        {
            ProxyMethodParameterInfos = new List<ProxyMethodParameterInfo>();
            Namespace = String.Empty;
            MethodNameWithNamespace = String.Empty;
        }
        #endregion

    }
}
