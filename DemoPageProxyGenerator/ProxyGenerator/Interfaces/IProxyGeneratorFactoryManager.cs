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
        ProxySettings GetProxySettings();
        IAngularJsProxyBuilder CreateAngularJsProxyBuilder();
        IAngularTsProxyBuilder CreateAngularTsProxyBuilder();
        IProxyBuilderDataTypeHelper CreateBuilderTypeHelper();
    }
}