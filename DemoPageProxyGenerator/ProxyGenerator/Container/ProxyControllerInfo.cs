using System;
using System.Collections.Generic;

namespace ProxyGenerator.Container
{
    public class ProxyControllerInfo
    {
        #region Member
        /// <summary>
        /// Der Name des Controllers OHNE den Controller Suffix
        /// </summary>
        public string ControllerNameWithoutSuffix { get; set; }

        /// <summary>
        /// Reflexion Type für den Aktuellen Controller
        /// </summary>
        public Type Controller { get; set; }

        public List<ProxyMethodInfos> ProxyMethodInfos { get; set; }
        #endregion

        #region Konstruktor
        public ProxyControllerInfo()
        {
            ProxyMethodInfos = new List<ProxyMethodInfos>();
        }
        #endregion
    }
}
