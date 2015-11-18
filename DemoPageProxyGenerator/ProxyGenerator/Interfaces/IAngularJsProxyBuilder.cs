using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IAngularJsProxyBuilder
    {
        ProxySettings ProxySettings { get; set; }
        string BuildProxy();
    }
}