using System.Collections.Generic;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IProxyBuilder
    {
        List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos);
    }
}