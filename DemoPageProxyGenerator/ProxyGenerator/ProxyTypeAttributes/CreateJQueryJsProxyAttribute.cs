using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    /// <summary>
    /// Dieses Attribut dient aktuell nur dem Markieren von Funktionen die in 
    /// einen JavaScript Proxy Funktion umgewandelt werden sollen für für jQuery
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CreateJQueryJsProxyAttribute : CreateProxyBaseAttribute
    {
    }
}
