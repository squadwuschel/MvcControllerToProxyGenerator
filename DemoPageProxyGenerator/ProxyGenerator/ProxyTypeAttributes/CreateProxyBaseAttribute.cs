using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    /// <summary>
    /// Dieses Attribut dient aktuell nur dem Markieren von Funktionen die in 
    /// eine JavaScript Proxy Funktion umgewandelt werden sollen.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class CreateProxyBaseAttribute : Attribute
    {
        public Type ReturnType { get; set; }

        public CreateProxyBaseAttribute()
        {
            ReturnType = null;
        }

        public CreateProxyBaseAttribute(Type returnType)
        {
            this.ReturnType = returnType;
        }
    }
}
