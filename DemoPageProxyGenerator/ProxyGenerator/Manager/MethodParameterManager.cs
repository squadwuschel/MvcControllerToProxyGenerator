using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class MethodParameterManager : IMethodParameterManager
    {
        #region Member
        #endregion



        #region Public Functions
        public List<ProxyMethodParameterInfo> LoadParameterInfos(MethodInfo methodInfo)
        {
            List<ProxyMethodParameterInfo> methodParameterInfos = new List<ProxyMethodParameterInfo>();

            //TODO ausprogrammieren

            return methodParameterInfos;
        }
        #endregion
    }
}
