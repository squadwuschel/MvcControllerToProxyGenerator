using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TextTemplating;

namespace ProxyGenerator.Interfaces
{
    public interface IAssemblyManager
    {
        List<Assembly> LoadAssemblies(string webprojectName, ITextTemplatingEngineHost host);
    }
}