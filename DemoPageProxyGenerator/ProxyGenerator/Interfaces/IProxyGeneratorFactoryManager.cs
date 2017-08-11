using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Manager;

namespace ProxyGenerator.Interfaces
{
    public interface IProxyGeneratorFactoryManager
    {
        IAssemblyManager CreateAssemblyManager();
        IFileHelper FileHelper();
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
        IProxyBuilder CreateJQueryJsProxyBuilder();
        ISettingsManager CreateSettingsManager();
        IProxyBuilder CreateAngular2TsProxyBuilder();
        LogManager GetLogManager();
    }
}