using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Builder.Helper
{
    public class ProxyBuilderDataTypeHelper : IProxyBuilderDataTypeHelper
    {
        #region Member
        public ProxySettings ProxySettings { get; set; }
        #endregion

        #region Konstruktor
        public ProxyBuilderDataTypeHelper(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
        }
        #endregion

        /// <summary>
        /// Gibt zurück der übergebenen Typ einen ReturnType hat.
        /// </summary>
        public bool HasReturnType(Type type)
        {
            if (type == null || type == typeof(void))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gibt den passenden TypeScript Datentyp zum übergebenen .NET Type Objekt zurück.
        /// </summary>
        /// <param name="type">.NET Type Objekt für das der TypeScript Typestring ermittelt werden soll.</param>
        public string GetTsType(Type type)
        {
            if (type == null || type == typeof(void))
            {
                return "void";
            }

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IEnumerable<>) || type.GetGenericTypeDefinition() == typeof(IList<>) || type.GetGenericTypeDefinition() == typeof(List<>) || type.GetGenericTypeDefinition() == typeof(ICollection<>)))
            {
                Type underlyingType = type.GetGenericArguments()[0];
                //Wir wissen das es sich um ein "Array" handelt jetzt noch den Typen ermitteln für das Array
                return GetTsType(underlyingType) + "[]";
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                Type keyType = type.GetGenericArguments()[0];
                Type valueType = type.GetGenericArguments()[1];
                //TypeLite stellt ein Dictionary z.B. folgendermaßen dar: System.Collections.Generic.KeyValuePair<string, T>[]
                return typeof (KeyValuePair<,>).FullName.Split('`')[0] + "<" + GetTsType(keyType) + ", " + GetTsType(valueType) + ">[]";
            }

            if (type.IsArray)
            {
                Type arrayType = type.GetElementType();
                //Wir wissen das es sich um ein Array handelt jetzt noch den Typen ermitteln für das Array
                return GetTsType(arrayType) + "[]";
            }

            //Man muss die Standard Systemtypen prüfen und den Wert zurückgeben der von TypScript entsprechend unterstützt wird.
            if (type == typeof(string))
            {
                return "string";
            }

            if (type == typeof(int) || type == typeof(int?) ||
                type == typeof(Int16) || type == typeof(Int16?) ||
                type == typeof(Int32) || type == typeof(Int32?) ||
                type == typeof(Int64) || type == typeof(Int64?) ||
                type == typeof(decimal) || type == typeof(decimal?) ||
                type == typeof(double) || type == typeof(double?) ||
                type == typeof(long) || type == typeof(long?) ||
                type == typeof(byte) || type == typeof(byte?) ||
                type == typeof(Single) || type == typeof(Single?))
            {
                return "number";
            }

            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                //Da es in TypeScript keinen Date Datentyp gibt den wir hier einfach so übergeben könne, wird Any als übergabewert verwendet.
                return "any";
            }

            if (type == typeof(Boolean) || type == typeof(Boolean?))
            {
                return "boolean";
            }

            //Für FileUpload muss hier Any als Type gesetzt werden
            if (type == typeof (HttpPostedFileBase))
            {
                return "any";
            }

            //Achtung Nullable Generics werden "anders" behandelt
            if (type.IsGenericType && type.GetGenericTypeDefinition() != typeof(Nullable<>))
            {
                //Wenn es sich um ein Generic handelt, dann sieht der FullName folgendermaßen aus:
                //UnitTests.TestHelper.TestClasses.Oberklasse`1[[UnitTests.TestHelper.TestClasses.Datenklasse, UnitTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
                //Daher das Split an dieser Stelle und die Rekursion, wenn mehrere Parameter übergeben werden.
                return this.AddInterfacePrefixToFullName(type.FullName.Split('`')[0], type.IsEnum) + "<" + string.Join(", ", type.GetGenericArguments().Select(GetTsType).ToArray()) + ">"; ;
            }

            //Prüfen ob es sich um einen Nullable Wert handelt
            //Da es in TypeScript keine NullAble Typen gibt wird hier einfach der zugrundeliegende Type zurückgegeben und NICHT die GenericDefinition mit Nullable<Type> 
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return this.AddInterfacePrefixToFullName(Nullable.GetUnderlyingType(type).FullName, type.IsEnum);
            }

            //Bei eigenen Typen muss der Namespace noch mit angegeben werden zum Namen.
            //Dem Returntype das Interface "I" hinzufügen und da es sich um eine Liste handelt ein JavaScript array daraus machen.
            return this.AddInterfacePrefixToFullName(type.FullName, type.IsEnum);
        }

        /// <summary>
        /// Anpassen eines Namespaces inkl. Type in Namespace und Interface z.B.:
        /// Aus: MyWebapp.Type.Address => MyWebapp.Type.IAddress
        /// </summary>
        public string AddInterfacePrefixToFullName(string fullNameWithNamespace, bool isEnum)
        {
            if (!string.IsNullOrEmpty(fullNameWithNamespace))
            {
                var entries = fullNameWithNamespace.Split('.');
                var oldStr = entries[entries.Length - 1];
                var newStr = isEnum ? entries[entries.Length - 1] : ProxySettings.TypeLiteInterfacePrefix + entries[entries.Length - 1];
                return fullNameWithNamespace.Remove(fullNameWithNamespace.LastIndexOf(oldStr), oldStr.Length) + newStr;
            }

            return fullNameWithNamespace;
        }

        /// <summary>
        /// Sucht einfach nur die Parameternamen der aktuell übergebenen Methode heraus und setzt noch den passenden Typ 
        /// für TypeScript hinter den Namen z.B.: "alter: number, name: string, ..."
        /// </summary>
        public string GetFunctionParametersWithType(_MethodInfo methodInfo)
        {
            StringBuilder builder = new StringBuilder();
            //Zusammenbauen der PrameterInfos für die übergebene Methode.
            foreach (ParameterInfo info in methodInfo.GetParameters())
            {
                //Die Parameterliste inkl. des Typen zurückgeben
                builder.Append(string.Format("{0}: {1}", info.Name, GetTsType(info.ParameterType))).Append(",");
            }

            return builder.ToString().TrimEnd(',');
        }
    }
}
