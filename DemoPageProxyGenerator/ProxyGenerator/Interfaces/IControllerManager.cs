using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProxyGenerator.Interfaces
{
    public interface IControllerManager
    {
        /// <summary>
        /// Alle Controller ermitteln die für das Projekt befunden werden können.
        /// </summary>
        List<Type> GetAllProxyController(List<Assembly> assemblies);

        /// <summary>
        /// Die Liste an Controllern ermitteln in denen das übergebene ProxyTypeAttribute gesetzt wurde.
        /// </summary>
        List<Type> GetProxyControllerByProxyTypeAttribute(Type proxyTypeAttribute, List<Type> allController);
    }
}