using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;

namespace ProxyGenerator
{
    public class Generator
    {
        private IAssemblyManager AssemblyManager { get; set; }
        private IControllerManager ControllerManager { get; set; }

        public Generator()
        {
            AssemblyManager = new AssemblyManager();
            ControllerManager = new ControllerManager();
        }

        public void GenerateProxy(string webprojectName, ITextTemplatingEngineHost host)
        {
            var assemblies = AssemblyManager.LoadAssemblies(webprojectName, host);
            var controller = ControllerManager.GetAllProxyController(assemblies);

        }
    }
}
