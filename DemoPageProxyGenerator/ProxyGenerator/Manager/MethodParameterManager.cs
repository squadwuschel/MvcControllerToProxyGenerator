using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class MethodParameterManager : IMethodParameterManager
    {
        #region Public Functions
        /// <summary>
        /// Laden der Parameter Informationen für alle Parameter der übergebenen Methodeninformationen.
        /// Ob es sich um einfachte Datentypen oder ein "complex" Objekt handelt.
        /// </summary>
        public List<ProxyMethodParameterInfo> LoadParameterInfos(MethodInfo methodInfo)
        {
            List<ProxyMethodParameterInfo> methodParameterInfos = new List<ProxyMethodParameterInfo>();

            //Alle Parameter der Methode durchgehen und die Typen prüfen
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                Type t = parameterInfo.ParameterType;
                if (t.IsPrimitive || t == typeof(decimal) || t == typeof(string) || t == typeof(long) ||
                    t == typeof(DateTime) || t == typeof(Int16) || t == typeof(Int32) ||
                    t == typeof(Int64) || t == typeof(bool) || t == typeof(Decimal?) ||
                    t == typeof(DateTime?) || t == typeof(Int16?) || t == typeof(Int32?) ||
                    t == typeof(Int64?) || t == typeof(bool?) || t == typeof(long?) || 
                    t== typeof(double) || t == typeof(double?) || t == typeof(Single) ||
                    t== typeof(Single?) || t == typeof(int) || t == typeof(int?) || 
                    t == typeof(byte) || t == typeof(byte?) || t.IsEnum)
                {
                    methodParameterInfos.Add(new ProxyMethodParameterInfo()
                    {
                        IsComplexeType = false,
                        ParameterName = parameterInfo.Name,
                        ParameterInfo = parameterInfo,
                        IsString = t == typeof(String)
                    });
                }
                else
                {
                    methodParameterInfos.Add(new ProxyMethodParameterInfo()
                    {
                        IsComplexeType = true,
                        ParameterName = parameterInfo.Name,
                        ParameterInfo = parameterInfo,
                        IsString = false
                    });
                }
            }

            //Es darf nur ein "komplexer" Parameter pro Controller "übergeben" werden.
            if (methodParameterInfos.Count(p => p.IsComplexeType) > 1)
            {
                throw new NotSupportedException("Warning a method with more than one 'complex' parameter was found, thats not supported by ProxyGenerator.");
            }

            return methodParameterInfos;
        }
        #endregion
    }
}
