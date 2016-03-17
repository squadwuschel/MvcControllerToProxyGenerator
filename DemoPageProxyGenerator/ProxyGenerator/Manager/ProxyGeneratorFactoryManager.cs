using ProxyGenerator.Builder;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class ProxyGeneratorFactoryManager : IProxyGeneratorFactoryManager
    {
        #region Member
        private ProxySettings ProxySettings { get; set; }
        #endregion

        #region Konstruktor
        public ProxyGeneratorFactoryManager(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
        }
        #endregion

        #region Creator Functions
        public IAssemblyManager CreateAssemblyManager()
        {
            return new AssemblyManager(this);
        }

        public IFileHelper FileHelper()
        {
            return new FileHelper(this);
        }

        public IControllerManager CreateControllerManager()
        {
            return new ControllerRoslinManager(this);
        }

        public IMethodManager CreateMethodManager()
        {
            return new MethodManager(this);
        }

        public IMethodParameterManager CreateMethodParameterManager()
        {
            return new MethodParameterManager();
        }

        public IProxyBuilderHelper CreateProxyBuilderHelper()
        {
            return new ProxyBuilderHelper(ProxySettings);
        }

        public IProxyBuilderHttpCall CreateProxyBuilderHttpCall()
        {
            return new ProxyBuilderHttpCall(this);
        }

        public IProxyBuilderDataTypeHelper CreateBuilderTypeHelper()
        {
            return new ProxyBuilderDataTypeHelper(ProxySettings);
        }
        #endregion

        #region Public Functions
        public ProxySettings GetProxySettings()
        {
            return ProxySettings;
        }
        #endregion

        #region ProxyBuilder Creator
        public IProxyBuilder CreateAngularJsProxyBuilder()
        {
            return new AngularJsProxyBuilder(this);
        }

        public IProxyBuilder CreateAngularTsProxyBuilder()
        {
            return new AngularTsProxyBuilder(this);
        }

        public IProxyBuilder CreateJQueryTsProxyBuilder()
        {
            return new JQueryTsProxyBuilder(this);
        }

        public IProxyBuilder CreateJQueryJsProxyBuilder()
        {
            return new JQueryJsProxyBuilder(this);
        }
        #endregion
    }
}   
