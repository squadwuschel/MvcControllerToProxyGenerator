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

        /// <summary>
        /// Tells the Proxy Generator to jsut create a window.location.href Link for this Proxy Function.
        /// </summary>
        public bool CreateWindowLocationHrefLink { get; set; }

        public CreateProxyBaseAttribute()
        {
            ReturnType = null;
            CreateWindowLocationHrefLink = false;
        }

        public CreateProxyBaseAttribute(Type returnType)
        {
            this.ReturnType = returnType;
            CreateWindowLocationHrefLink = false;
        }
    }
}
