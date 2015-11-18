using System.Collections.Generic;
using System.Reflection;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IMethodParameterManager
    {
        List<ProxyMethodParameterInfo> LoadParameterInfos(MethodInfo methodInfo);
    }
}