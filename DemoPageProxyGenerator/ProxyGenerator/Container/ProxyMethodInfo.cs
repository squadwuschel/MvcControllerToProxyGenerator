using System;
using System.Collections.Generic;
using System.Reflection;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Container
{
    public class MethodInfos
    {
        #region Member
        /// <summary>
        /// Der Name der Methode
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Der aktuelle Namespace der Methode
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Dem Proxy Attribut kann man einen Returntype hinterlegen, dieser wird hier zurückgegeben
        /// </summary>
        public Type ReturnType { get; set; }

        /// <summary>
        /// Reflexion Type für die Methode
        /// </summary>
        public MethodInfo MethodInfo { get; set; }

        /// <summary>
        /// Die Parameter der MEthode die übergeben werden in der richtigen Reihenfolge.
        /// </summary>
        public List<ProxyMethodParameterInfo> ProxyMethodParameterInfos { get; set; }
        #endregion

        #region Konstruktor
        public MethodInfos()
        {
            ProxyMethodParameterInfos = new List<ProxyMethodParameterInfo>();
            MethodName = string.Empty;
            Namespace = String.Empty;
        }
        #endregion

    }
}
