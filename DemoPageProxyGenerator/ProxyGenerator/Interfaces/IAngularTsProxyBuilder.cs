using System.Collections.Generic;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IAngularTsProxyBuilder
    {
        List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos);
        IProxyGeneratorFactoryManager Factory { get; set; }
    }
}