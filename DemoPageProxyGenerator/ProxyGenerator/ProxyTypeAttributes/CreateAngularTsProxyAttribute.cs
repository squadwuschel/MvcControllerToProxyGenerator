using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    /// <summary>
    /// Dieses Attribut dient aktuell nur dem Markieren von Funktionen die in 
    /// eine TypeScript Proxy Funktion umgewandelt werden sollen für AngularJs
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CreateAngularTsProxyAttribute : CreateProxyBaseAttribute
    {
    }
}
