using System.Collections.Generic;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IAngularJsProxyBuilder
    {
        ProxySettings ProxySettings { get; set; }
        List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos);
    }
}