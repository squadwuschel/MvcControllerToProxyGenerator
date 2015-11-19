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
        public List<ProxyMethodParameterInfo> LoadParameterInfos(MethodInfo methodInfo)
        {
            List<ProxyMethodParameterInfo> methodParameterInfos = new List<ProxyMethodParameterInfo>();

            //Alle Parameter der Methode duirchgehen und die Typen prüfen
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                Type t = parameterInfo.ParameterType;
                if (t.IsPrimitive || t == typeof(Decimal) || t == typeof(String) ||
                    t == typeof(DateTime) || t == typeof(Int16) || t == typeof(Int32) ||
                    t == typeof(Int64) || t == typeof(Boolean) || t == typeof(Decimal?) ||
                    t == typeof(DateTime?) || t == typeof(Int16?) || t == typeof(Int32?) ||
                    t == typeof(Int64?) || t == typeof(Boolean?))
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
                throw new Exception("Achtung mehr wie einen 'komplexen' Parameter entdeckt - dies wird vom Proxygenerator und .NET nicht unterstützt.");
            }

            return methodParameterInfos;
        }
        #endregion
    }
}
