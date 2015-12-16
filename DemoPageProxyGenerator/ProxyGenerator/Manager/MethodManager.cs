using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Manager
{
    public class MethodManager : IMethodManager
    {
        #region Member
        public IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public MethodManager(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Laden der Methodeninformationen für die übergebene Klasse (Controller)
        /// </summary>
        public List<ProxyMethodInfos> LoadMethodInfos(Type controller, Type proxyTypeAttribute)
        {
            List<ProxyMethodInfos> proxyMethodInfos = new List<ProxyMethodInfos>();

            //Alle Methoden des Controllers durchgehen und nur die Methoden ermitteln in denen auch das übergebene ProxyAttribut enthalten ist.
            foreach (MethodInfo methodInfo in controller.GetMethods().Where(p => p.GetCustomAttributes(true).Any(attr => attr.GetType() == proxyTypeAttribute)))
            {
                if (proxyMethodInfos.Any(p => p.MethodInfo.Name == methodInfo.Name))
                {
                    throw new Exception(string.Format("Achtung, da JavaScript keine Überladung von Methoden unterstützt, bitte eine der Methoden '{0}' umbenennen", methodInfo.Name));
                }

                ProxyMethodInfos proxyMethodInfo = new ProxyMethodInfos();
                //Laden der Paramterinformationen zu unserer Methode.
                proxyMethodInfo.ProxyMethodParameterInfos = Factory.CreateMethodParameterManager().LoadParameterInfos(methodInfo);
                proxyMethodInfo.MethodInfo = methodInfo;
                proxyMethodInfo.Controller = controller;
                proxyMethodInfo.ReturnType = GetProxyReturnType(methodInfo);

                if (methodInfo.DeclaringType != null)
                {
                    proxyMethodInfo.Namespace = methodInfo.DeclaringType.FullName;
                    proxyMethodInfo.MethodNameWithNamespace = string.Format("{0}.{1}", proxyMethodInfo.Namespace, methodInfo.Name);

                }

                proxyMethodInfos.Add(proxyMethodInfo);
            }

            return proxyMethodInfos;
        }

        /// <summary>
        /// Zur übergebenen MethodInformation in den Attributen prüfen ob wir unser CustomAttribut gesetzt haben und wenn ja 
        /// Das Attribut ReturnType ermiteln und dessen Type zurückgeben.
        /// </summary>
        public Type GetProxyReturnType(MethodInfo methodInfo)
        {
            CreateProxyBaseAttribute attr = methodInfo.GetCustomAttributes(typeof(CreateProxyBaseAttribute), false).FirstOrDefault() as CreateProxyBaseAttribute;
            if (attr != null)
            {
                //Es ist aktuell sehr umständlich hier Interfaces zu verwenden.
                if (attr.ReturnType != null && attr.ReturnType.IsInterface)
                {
                    throw new Exception(string.Format("Bitte keine Interfaces als 'ReturnType' für 'CreateProxy' verwenden: '{0}'", attr.ReturnType.Name));
                }
                return attr.ReturnType;
            }

            return null;
        }
        #endregion
    }
}
