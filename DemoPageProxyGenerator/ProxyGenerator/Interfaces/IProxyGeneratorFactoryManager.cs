using ProxyGenerator.Builder;
using ProxyGenerator.Container;

namespace ProxyGenerator.Interfaces
{
    public interface IProxyGeneratorFactoryManager
    {
        IAssemblyManager CreateAssemblyManager();
        IControllerManager CreateControllerManager();
        IMethodManager CreateMethodManager();
        IMethodParameterManager CreateMethodParameterManager();
        IProxyBuilderHelper CreateProxyBuilderHelper();
        IProxyBuilderHttpCall CreateProxyBuilderHttpCall();
        IProxyBuilderDataTypeHelper CreateBuilderTypeHelper();
        ProxySettings GetProxySettings();
        IProxyBuilder CreateAngularJsProxyBuilder();
        IProxyBuilder CreateAngularTsProxyBuilder();
        IProxyBuilder CreateJQueryTsProxyBuilder();
    }
}