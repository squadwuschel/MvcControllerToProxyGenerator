using System;
using System.Collections.Generic;
using System.Reflection;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IControllerManager
    {
        /// <summary>
        /// Alle Controller ermitteln die für das Projekt befunden werden können.
        /// </summary>
        List<Type> GetAllProjectProxyController(ProxySettings proxySettings);

        /// <summary>
        /// Die Liste an Controllern ermitteln in denen das übergebene ProxyTypeAttribute gesetzt wurde.
        /// </summary>
        List<Type> GetProxyControllerByProxyTypeAttribute(Type proxyTypeAttribute, List<Type> allController);

        /// <summary>
        /// Laden aller Methoden und Parameterinformationen in allen Controllerm in denen das übergebene ProxyType Attribut verwendet wird.
        /// </summary>
        List<ProxyControllerInfo> LoadProxyControllerInfos(Type proxyTypeAttribute, List<Type> allController);
    }
}