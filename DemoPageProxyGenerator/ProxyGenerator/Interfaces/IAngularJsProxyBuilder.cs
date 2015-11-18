using System.Collections.Generic;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IAngularJsProxyBuilder
    {
        ProxySettings ProxySettings { get; set; }
        IAssemblyManager AssemblyManager { get; set; }
        IControllerManager ControllerManager { get; set; }
        List<GeneratedProxyEntry> BuildProxy();
    }
}