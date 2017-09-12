using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    /// <summary>
    /// Ermittelt alle Assemblies für das aktuelle Projekt
    /// </summary>
    public class AssemblyManager : IAssemblyManager
    {
        #region Member
        private List<Assembly> _allAssemblies = null;
        IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public AssemblyManager(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
        }
        #endregion

        /// <summary>
        /// Laden der Assemblies die überprüft werden müssen, ob diese das Attribut zum Erstellen eines Proxies enthalten.
        /// </summary>
        /// <param name="webprojectName">Der Name des WebProjektes in dem wir die Assemblies laden</param>
        /// <param name="fullPathToTheWebProject">Der Komplette Pfad zum WebProjekt, wenn es sich um ein Subverzeichnis handelt, wird der Weg bis zum Projekt genommen</param>
        public List<Assembly> LoadAssemblies(string webprojectName, string fullPathToTheWebProject)
        {
            if (_allAssemblies == null)
            {
                _allAssemblies = new List<Assembly>();

                //Den Pfad zum T4 Template ermitteln
                var webProjectPath = Factory.FileHelper().GetParentDirectory(fullPathToTheWebProject, webprojectName);
                foreach (string dll in Directory.GetFiles(webProjectPath, "*.dll", SearchOption.AllDirectories))
                {
                    try
                    {
                        _allAssemblies.Add(Assembly.LoadFile(dll));
                    }
                    catch (Exception exception)
                    {
                        Factory.GetLogManager().AddMessage($"Fehler beim Laden der Assembly '{dll}'", exception.ToString());

                        if (exception is System.Reflection.ReflectionTypeLoadException)
                        {
                            var typeLoadException = exception as ReflectionTypeLoadException;
                            var loaderExceptions = typeLoadException.LoaderExceptions;

                            loaderExceptions?.ToList().ForEach(p =>
                            {
                                Factory.GetLogManager().AddMessage(p.Message, string.Empty);
                            });
                        }
                    }
                }
            }

            return _allAssemblies;
        }


    }
}
