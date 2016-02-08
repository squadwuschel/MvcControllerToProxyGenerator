using System;
using System.Collections.Generic;
using System.Reflection;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IProxyBuilderHelper
    {
        /// <summary>
        /// Gibt den Dateinamen des Proxies zurück
        /// </summary>
        /// <param name="controllerName">Der Name des Controllers ohne das "Controller" davor</param>
        /// <param name="controllerSuffix">Der Suffix der an den namen des Controllers angehängt wird, z.b.: PSrv</param>
        /// <param name="fileExtension">Die Dateienung z.B. js oder ts</param>
        string GetProxyFileName(string controllerName, string controllerSuffix, string fileExtension);

        /// <summary>
        /// Den Namen des Services ermitteln anhand des Namens des Controllers
        /// </summary>
        /// <param name="controllerName">Der Name des Controllers beginnt mit kleinem Buchstaben</param>
        /// <param name="controllerSuffix">Der Suffix der an den namen des Controllers angehängt wird, z.b.: PSrv</param>
        string GetServiceName(string controllerName, string controllerSuffix, bool lowerFirstCharInFunctionName);

        /// <summary>
        /// Den Namen der Methode ermitteln der gesetzt werden soll für den Funktionsaufruf.
        /// </summary>
        /// <param name="methodname">Der Name der Methode z.B. GetAllPersons</param>
        string GetProxyFunctionName(string methodname);

        /// <summary>
        /// Sucht nur die Parameternamen der aktuell übergebenen Methode heraus und baut einen Kommaseperierten String mit den Parameternamen.
        /// </summary>
        string GetFunctionParameters(MethodInfo methodInfo);

        /// <summary>
        /// Prüfen ob die übergebnene Methode das übergenene Attribut besitzt.
        /// </summary>
        /// <param name="attribute">Der Typ des Attributs der überprüft werden soll</param>
        /// <param name="method">Die Methode bei der das Attribut gesucht werden soll</param>
        bool HasAttribute(Type attribute, MethodInfo method);

        /// <summary>
        /// Ermittelt den Namen des Controller ohne die Endung "Controller",
        /// da wir diese nie mit angeben müssen.
        /// </summary>
        string GetClearControllerName(Type controller);

        /// <summary>
        /// Zusammenbauen der passenden URL Parameter ACHTUNG der UrlParameterName entspricht 
        /// auch dem gleichen Namen wie der Parameter der gesetzt wird.
        /// </summary>
        /// <param name="infos">List mit den Typen die als URL Parameter angelegt werden sollen.</param>
        string BuildUrlParameter(List<ProxyMethodParameterInfo> infos);

        /// <summary>
        /// Prüfen ob eine Id enthalten ist, diese wird extra an die URL angehängt.
        /// </summary>
        string BuildUrlParameterId(List<ProxyMethodParameterInfo> infos);
    }
}