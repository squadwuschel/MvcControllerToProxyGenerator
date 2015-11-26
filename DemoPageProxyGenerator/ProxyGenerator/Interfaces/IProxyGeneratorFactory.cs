using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public interface IProxyGeneratorFactory
    {
        IAssemblyManager CreateAssemblyManager();
        IControllerManager CreateControllerManager();
        IMethodManager CreateMethodManager();
        IMethodParameterManager CreateMethodParameterManager();
        IProxyBuilderHelper CreateProxyBuilderHelper();
        IProxyBuilderHttpCall CreateProxyBuilderHttpCall();
        //IAngularJsProxyBuilder CreateAngularJsProxyBuilder();
        ProxySettings GetProxySettings();
        IAngularJsProxyBuilder CreateAngularJsProxyBuilder();
    }
}