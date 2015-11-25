using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder
{
    public class ProxyBuilderHelper : IProxyBuilderHelper
    {
        #region Member
        public ProxySettings ProxySettings { get; set; }
        #endregion

        #region Konstruktor
        public ProxyBuilderHelper(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Gibt den Dateinamen des Proxies zurück
        /// </summary>
        /// <param name="controllerName">Der Name des Controllers ohne das "Controller" davor</param>
        /// <param name="controllerSuffix">Der Suffix der an den namen des Controllers angehängt wird, z.b.: PSrv</param>
        /// <param name="fileExtension">Die Dateienung z.B. js oder ts</param>
        public string GetProxyFileName(string controllerName, string controllerSuffix, string fileExtension)
        {
            return string.Format("{0}{1}.{2}", Char.ToLowerInvariant(controllerName[0]) + controllerName.Substring(1), controllerSuffix, fileExtension);
        }

        /// <summary>
        /// Den Namen des Services ermitteln anhand des Namens des Controllers
        /// </summary>
        /// <param name="controllerSuffix">Der Suffix der an den namen des Controllers angehängt wird, z.b.: PSrv</param>
        /// <param name="controllerName">Der Name des Controllers beginnt mit kleinem Buchstaben</param>
        public string GetServiceName(string controllerName, string controllerSuffix)
        {
            return string.Format("{0}{1}", Char.ToLowerInvariant(controllerName[0]) + controllerName.Substring(1), controllerSuffix);
        }

        /// <summary>
        /// Den Namen der Methode ermitteln der gesetzt werden soll für den Funktionsaufruf.
        /// </summary>
        /// <param name="methodname">Der Name der Methode z.B. GetAllPersons</param>
        public string GetProxyFunctionName(string methodname)
        {
            if (ProxySettings.LowerFirstCharInFunctionName)
            {
                return Char.ToLowerInvariant(methodname[0]) + methodname.Substring(1);
            }

            return methodname;
        }

        /// <summary>
        /// Sucht nur die Parameternamen der aktuell übergebenen Methode heraus und baut einen Kommaseperierten String mit den Parameternamen.
        /// </summary>
        public string GetFunctionParameters(MethodInfo methodInfo)
        {
            StringBuilder builder = new StringBuilder();
            //Zusammenbauen der PrameterInfos für die übergebene Methode.
            foreach (ParameterInfo info in methodInfo.GetParameters())
            {
                builder.Append(info.Name).Append(",");
            }

            return builder.ToString().TrimEnd(',');
        }

        /// <summary>
        /// Prüfen ob die übergebnene Methode das übergenene Attribut besitzt.
        /// </summary>
        /// <param name="attribute">Der Typ des Attributs der überprüft werden soll</param>
        /// <param name="method">Die Methode bei der das Attribut gesucht werden soll</param>
        public bool HasAttribute(Type attribute, MethodInfo method)
        {
            var found = from attr in method.GetCustomAttributes(true) where attr.GetType() == attribute select attr;
            return found.Any();
        }

        /// <summary>
        /// Ermittelt den Namen des Controller ohne die Endung "Controller",
        /// da wir diese nie mit angeben müssen.
        /// </summary>
        public string GetClearControllerName(Type controller)
        {
            string name = controller.Name;
            return name.Substring(0, name.LastIndexOf(ConstValues.ControllerNameSuffix));
        }
  
        /// <summary>
        /// Zusammenbauen der passenden URL Parameter ACHTUNG der UrlParameterName entspricht 
        /// auch dem gleichen Namen wie der Parameter der gesetzt wird.
        /// </summary>
        /// <param name="infos">List mit den Typen die als URL Parameter angelegt werden sollen.</param>
        public string BuildUrlParameter(List<ProxyMethodParameterInfo> infos)
        {
            StringBuilder builder = new StringBuilder();
            var allowedInfos = infos.Where(p => !p.IsComplexeType && p.ParameterName.ToLower() != "id");
            if (allowedInfos.Any())
            {
                builder.Append("+ '?");
            }

            bool isFirst = true;

            foreach (ProxyMethodParameterInfo info in allowedInfos)
            {
                //Prüfen ob es sich um einen String handelt der übergeben werden soll,
                //wenn ja wird dieser Url Encoded damit z.B. auch "+" Zeichen übermittelt werden
                string paramValue = info.IsString ? string.Format("encodeURIComponent({0})", info.ParameterName) : info.ParameterName;

                if (isFirst)
                {
                    builder.Append(string.Format("{0}='+{1}", info.ParameterName, paramValue));
                    isFirst = false;
                }
                else
                {
                    builder.Append(string.Format("+'&{0}='+{1}", info.ParameterName, paramValue));
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Prüfen ob eine Id enthalten ist, diese wird extra an die URL angehängt.
        /// </summary>
        public string BuildUrlParameterId(List<ProxyMethodParameterInfo> infos)
        {
            StringBuilder builder = new StringBuilder();
            //ACHTUNG der Wert mit dem Namen "id" wird direkt an die URL angehängt und nicht als Extra Parameter verwendet
            if (infos.Any(p => p.ParameterName.ToLower() == "id"))
            {
                builder.Append(" + '/' + ").Append(infos.FirstOrDefault(p => p.ParameterName.ToLower() == "id").ParameterName);
            }

            return builder.ToString();
        }
        #endregion
    }
}
