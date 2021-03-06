﻿using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    /// <summary>
    /// Dieses Attribut dient aktuell nur dem Markieren von Funktionen die in 
    /// eine TypeScript Proxy Funktion umgewandelt werden sollen für jQuery
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CreateJQueryTsProxyAttribute : CreateProxyBaseAttribute
    {
    }
}
