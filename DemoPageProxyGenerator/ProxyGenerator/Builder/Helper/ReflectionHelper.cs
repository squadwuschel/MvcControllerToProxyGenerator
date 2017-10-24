using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGenerator.Builder.Helper
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Da es in .NET 4.0 noch kein "AttributeType" und "GetAllBaseTypes()" Extension gibt, 
        /// hier ein passender Helper der zu einem Typ alle Basistypen zurück gibt
        /// </summary>
        public static ICollection<Type> GetAllBaseTypes(Type type)
        {
            var types = new List<Type>();
            //wenn der Type bei Object angekommen ist, dann ist type = null da der Type von Object == null ist!
            while (type != null)
            {
                types.Add(type);
                type = type.BaseType;
            }
            return types;
        }

        public static bool MyHasCustomAttributesData(this IList<CustomAttributeData> data, Type attribute)
        {
            return data.Any(atr => GetAllBaseTypes(atr.Constructor.DeclaringType).Select(_ => _.FullName).Contains(attribute.FullName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute">z.B. "CreateProxyBaseAttribute"</param>
        /// <param name="propertyName">z.B. "ReturnType"</param>
        /// <returns></returns>
        public static CustomAttributeNamedArgument? MyGetCustomAttributesData(this IList<CustomAttributeData> data, Type attribute, string propertyName)
        {
            var daten = data.Where(atr => GetAllBaseTypes(atr.Constructor.DeclaringType).Select(_ => _.FullName).Contains(attribute.FullName)).ToArray().FirstOrDefault();
            return daten?.NamedArguments?.FirstOrDefault(_ => _.MemberInfo.Name == propertyName);
        }
    }
}
