using System.Collections.Generic;
using System.Reflection;

namespace ProxyGenerator.Interfaces
{
    public interface IAssemblyManager
    {
        List<Assembly> LoadAssemblies(string webprojectName, string fullPathToTheWebProject);
    }
}