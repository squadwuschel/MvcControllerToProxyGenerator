using System.Linq;
using System.Text;
using System.Web.Mvc;
using ProxyGenerator.Container;
using ProxyGenerator.Enums;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder.Helper
{
    public class ProxyBuilderHttpCall : IProxyBuilderHttpCall
    {
        #region Member
        public IProxyGeneratorFactoryManager Factory { get; set; }
        public IProxyBuilderHelper ProxyBuilderHelper { get; set; }
        #endregion

        #region Konstruktor

        public ProxyBuilderHttpCall(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
            ProxyBuilderHelper = Factory.CreateProxyBuilderHelper();
        }
        #endregion

        #region Build HTTP Call
        /// <summary>
        /// Den passenden HttpCall zusammenbauen und prüfen ob Post oder Get verwendet werden soll
        /// Erstellt wird: post("/Home/LoadAll", data) oder get("/Home/LoadAll?userId=" + id)
        /// </summary>
        public string BuildHttpCall(ProxyMethodInfos methodInfo, ProxyBuilder proxyBuilder)
        {
            //Wie genau das Post oder Geht aussieht, hängt von den gewünschten Parametern ab.
            //Aktuell gehen wir von einer StandardRoute aus und wenn ein "id" in den Parametern ist, dann
            //Handelt es sich z.B. um den Letzten Parameter in der StandardRoute.
            //Beispiele:
            //.post("/Home/GetAutosByHerstellerId/" + id, message)
            //.post("/ControllerName/GetAutosByHerstellerId/", message)
            //get("/Home/GetSuccessMessage")
            //get("/Home/GetSuccessMessage/" + id + "?name=" + urlencodestring + "&test=2")

            //Prüfen ob ein complexer Typ verwendet wird.
            if (methodInfo.ProxyMethodParameterInfos.Count(p => p.IsComplexeType) == 0)
            {
                //Wenn über der Controller Action Post angegeben wurde, dann auch Post verwenden
                //obwohl kein komplexer Typ enthalten ist.
                if (ProxyBuilderHelper.HasAttribute(typeof(HttpPostAttribute), methodInfo.MethodInfo))
                {
                    if (proxyBuilder == ProxyBuilder.jQueryTypeScript || proxyBuilder == ProxyBuilder.jQueryJavaScript)
                    {
                        return BuildPostjQuery(methodInfo);
                    }

                    return BuildPostAngular(methodInfo);
                }

                //Kein Komplexer Typ also Get verwenden.
                return BuildGet(methodInfo);
            }

            if (proxyBuilder == ProxyBuilder.jQueryTypeScript || proxyBuilder == ProxyBuilder.jQueryJavaScript)
            {
                return BuildPostjQuery(methodInfo);
            }

            return BuildPostAngular(methodInfo);
        }

        /// <summary>
        /// Rückgabe für Post erstellen für Angular Calls
        /// </summary>
        /// <returns>Gibt den passenden POST Aufruf zurück</returns>
        private string BuildPostAngular(ProxyMethodInfos infos)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("post('{0}/{1}'", ProxyBuilderHelper.GetClearControllerName(infos.Controller), infos.MethodInfo.Name));

            builder.Append(ProxyBuilderHelper.BuildUrlParameterId(infos.ProxyMethodParameterInfos));
            builder.Append(ProxyBuilderHelper.BuildUrlParameter(infos.ProxyMethodParameterInfos));

            //Da auch ein Post ohne komplexen Typ aufgerufen werden kann über das "HttpPost" Attribut hier prüfen
            //ob ein komplexer Typ enthalten ist.
            if (infos.ProxyMethodParameterInfos.Any(p => p.IsComplexeType))
            {
                //Da es nur einen Complexen Typ geben darf pro Methodenaufruf, hier prüfen ob ein FileUpload dabei ist.
                if (infos.ProxyMethodParameterInfos.Any(p => p.IsFileUpload))
                {
                    //Achtung die "formData" Variable wird bei "#FunctionContent#" eingefügt
                    builder.Append(",formData, { transformRequest: angular.identity, headers: { 'Content-Type': undefined }})");
                }
                else
                {
                    //Standard Post 
                    builder.Append(string.Format(",{0})", infos.ProxyMethodParameterInfos.First(p => p.IsComplexeType).ParameterName));
                }
            }
            else
            {
                builder.Append(")");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Rückgabe für Post erstellen für jQuery Calls
        /// </summary>
        /// <returns>Gibt den passenden POST Aufruf zurück</returns>
        private string BuildPostjQuery(ProxyMethodInfos infos)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("ajax( {{ url : '{0}/{1}'", ProxyBuilderHelper.GetClearControllerName(infos.Controller), infos.MethodInfo.Name));

            builder.Append(ProxyBuilderHelper.BuildUrlParameterId(infos.ProxyMethodParameterInfos));
            builder.Append(ProxyBuilderHelper.BuildUrlParameter(infos.ProxyMethodParameterInfos));

            //Da auch ein Post ohne komplexen Typ aufgerufen werden kann über das "HttpPost" Attribut hier prüfen
            //ob ein komplexer Typ enthalten ist.
            if (infos.ProxyMethodParameterInfos.Any(p => p.IsComplexeType))
            {
                //Da es nur einen Complexen Typ geben darf pro Methodenaufruf, hier prüfen ob ein FileUpload dabei ist.
                if (infos.ProxyMethodParameterInfos.Any(p => p.IsFileUpload))
                {
                    //Achtung die "formData" Variable wird bei "#FunctionContent#" eingefügt
                    builder.Append(", data : formData, processData : false, contentType: false, type : \"POST\" })");
                }
                else
                {
                    //Standard Post 
                    builder.Append(string.Format(", data : JSON.stringify({0}), type : \"POST\", contentType: \"application/json; charset=utf-8\" }})", infos.ProxyMethodParameterInfos.First(p => p.IsComplexeType).ParameterName));
                }
            }
            else
            {
                builder.Append("})");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Rückgabe für Get erstellen
        /// </summary>
        /// <returns>Gibt den passenden GET Aufruf in JavaScript zurück</returns>
        private string BuildGet(ProxyMethodInfos infos)
        {
            StringBuilder builder = new StringBuilder();
            //Keine Komplexen Typen, einfacher Get Aufruf.
            builder.Append(string.Format("get('{0}/{1}'", ProxyBuilderHelper.GetClearControllerName(infos.Controller), infos.MethodInfo.Name));
            builder.Append(ProxyBuilderHelper.BuildUrlParameterId(infos.ProxyMethodParameterInfos));
            builder.Append(ProxyBuilderHelper.BuildUrlParameter(infos.ProxyMethodParameterInfos));
            builder.Append(")");
            return builder.ToString();
        }
        #endregion
    }
}
