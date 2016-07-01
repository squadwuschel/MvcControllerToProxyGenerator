using System;

namespace ProxyGenerator.ProxyTypeAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CreateAngularTsImplementsForServiceAttribute : Attribute
    {
        public Type Implements { get; set; }

        public CreateAngularTsImplementsForServiceAttribute()
        {
            Implements = null;
        }

        public CreateAngularTsImplementsForServiceAttribute(Type implements)
        {
            this.Implements = implements;
        }
    }
}
