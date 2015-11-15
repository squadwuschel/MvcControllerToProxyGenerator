using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    /// <summary>
    /// Dieses Attribut dient aktuell nur dem Markieren von Funktionen die in 
    /// eine JavaScript Proxy Funktion umgewandelt werden sollen.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class CreateProxyAttribute : Attribute
    {
        public Type ReturnType { get; set; }

        public DataTypeEnum DataType { get; set; }

        public CreateProxyAttribute()
        {
            ReturnType = null;
        }

        public CreateProxyAttribute(Type returnType)
        {
            this.ReturnType = returnType;
        }

        public CreateProxyAttribute(Type returnType, DataTypeEnum dataType)
        {
            this.ReturnType = returnType;
            this.DataType = dataType;
        }

        public CreateProxyAttribute(DataTypeEnum dataType)
        {
            this.DataType = dataType;
        }
    }
}
