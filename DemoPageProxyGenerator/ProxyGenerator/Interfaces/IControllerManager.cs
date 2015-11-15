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
    }
}