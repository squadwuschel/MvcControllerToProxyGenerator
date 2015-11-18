using System;
using System.Collections.Generic;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IMethodManager
    {
        List<ProxyMethodInfos> LoadMethodInfos(Type controller, Type proxyTypeAttribute);
    }
}