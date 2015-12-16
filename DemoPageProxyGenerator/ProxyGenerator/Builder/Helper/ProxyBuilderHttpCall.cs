﻿using System.Linq;
using System.Text;
using System.Web.Mvc;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;

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
        public string BuildHttpCall(ProxyMethodInfos methodInfo)
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
                    return BuildPost(methodInfo);
                }

                //Kein Komplexer Typ also Get verwenden.
                return BuildGet(methodInfo);
            }

            return BuildPost(methodInfo);
        }

        /// <summary>
        /// Rückgabe für Post erstellen
        /// </summary>
        /// <returns>Gibt den passenden POST Aufruf in JavaScript zurück</returns>
        private string BuildPost(ProxyMethodInfos infos)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("post('{0}/{1}'", ProxyBuilderHelper.GetClearControllerName(infos.Controller), infos.MethodInfo.Name));

            builder.Append(ProxyBuilderHelper.BuildUrlParameterId(infos.ProxyMethodParameterInfos));
            builder.Append(ProxyBuilderHelper.BuildUrlParameter(infos.ProxyMethodParameterInfos));

            //Da auch ein Post ohne komplexen Typ aufgerufen werden kann über das "HttpPost" Attribut hier prüfen
            //ob ein komplexer Typ enthalten ist.
            if (infos.ProxyMethodParameterInfos.Any(p => p.IsComplexeType))
            {
                builder.Append(string.Format(",{0})", infos.ProxyMethodParameterInfos.First(p => p.IsComplexeType).ParameterName));
            }
            else
            {
                builder.Append(")");
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
