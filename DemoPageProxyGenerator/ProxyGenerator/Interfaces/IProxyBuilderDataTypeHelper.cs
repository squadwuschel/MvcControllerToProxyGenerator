using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ProxyGenerator.Interfaces
{
    public interface IProxyBuilderDataTypeHelper
    {
        /// <summary>
        /// Gibt den passenden TypeScript Datentyp zum übergebenen .NET Type Objekt zurück.
        /// </summary>
        /// <param name="type">.NET Type Objekt für das der TypeScript Typestring ermittelt werden soll.</param>
        string GetTsType(Type type);

        /// <summary>
        /// Anpassen eines Namespaces inkl. Type in Namespace und Interface z.B.:
        /// Aus: MyWebapp.Type.Address => MyWebapp.Type.IAddress
        /// </summary>
        string AddInterfacePrefixToFullName(string fullNameWithNamespace, bool isEnum);

        /// <summary>
        /// Sucht einfach nur die Parameternamen der aktuell übergebenen Methode heraus und setzt noch den passenden Typ 
        /// für TypeScript hinter den Namen z.B.: "alter: number, name: string, ..."
        /// </summary>
        string GetFunctionParametersWithType(_MethodInfo methodInfo);

        /// <summary>
        /// Gibt zurück der übergebenen Typ einen ReturnType hat.
        /// </summary>
        bool HasReturnType(Type type);
    }
}