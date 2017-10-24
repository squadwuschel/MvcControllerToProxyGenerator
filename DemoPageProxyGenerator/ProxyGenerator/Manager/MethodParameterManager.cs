using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
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
                Type type = parameterInfo.ParameterType;
                if (type.IsPrimitive || type == typeof(decimal) || type == typeof(string) || type == typeof(long) ||
                    type == typeof(DateTime) || type == typeof(Int16) || type == typeof(Int32) ||
                    type == typeof(Int64) || type == typeof(bool) || type == typeof(Decimal?) ||
                    type == typeof(DateTime?) || type == typeof(Int16?) || type == typeof(Int32?) ||
                    type == typeof(Int64?) || type == typeof(bool?) || type == typeof(long?) || 
                    type== typeof(double) || type == typeof(double?) || type == typeof(Single) ||
                    type== typeof(Single?) || type == typeof(int) || type == typeof(int?) || 
                    type == typeof(byte) || type == typeof(byte?) || type.IsEnum)
                {
                    methodParameterInfos.Add(new ProxyMethodParameterInfo()
                    {
                        IsComplexeType = false,
                        ParameterName = parameterInfo.Name,
                        ParameterInfo = parameterInfo,
                        IsString = type.FullName == typeof(String).FullName,
                        IsFileUpload = false
                    });
                }
                else
                {
                    methodParameterInfos.Add(new ProxyMethodParameterInfo()
                    {
                        IsComplexeType = true,
                        ParameterName = parameterInfo.Name,
                        ParameterInfo = parameterInfo,
                        IsString = false,
                        //Prüfen ob es sich um einen FileUpload handelt - ist immer Complex Type
                        IsFileUpload = typeof(HttpPostedFileBase).FullName == type.FullName
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
