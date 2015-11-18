using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProxyGenerator.Container
{
    public class ProxyMethodParameterInfo
    {
        #region Member
        /// <summary>
        /// Reflexion Objekt für die Parameter Informationen
        /// </summary>
        public ParameterInfo ParameterInfo { get; set; }

        /// <summary>
        /// Der Name des Parameters
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gibt an ob es sich um einen komplexen Typen handelt. Es handelt sich dann nicht
        /// mehr um einen "einfachen" Typen wie z.B.: String, Int, Bool. Sondern um eine
        /// eigene Klasse wie Auto, Person, ... Diese Daten müssen dann per POST übergeben werden.
        /// </summary>
        public bool IsComplexeType { get; set; }

        /// <summary>
        /// Gibt an ob es sich um einen String handelt, denn dieser muss
        /// auf JavaScript Seite UrlEncoded werden.
        /// </summary>
        public bool IsString { get; set; }
        #endregion

        #region Konstruktor
        public ProxyMethodParameterInfo()
        {
            ParameterName = String.Empty;
            IsComplexeType = false;
            IsString = false;
        }
        #endregion
    }
}
