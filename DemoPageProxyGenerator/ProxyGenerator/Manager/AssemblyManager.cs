using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    /// <summary>
    /// Ermittelt alle Assemblies für das aktuelle Projekt
    /// </summary>
    public class AssemblyManager : IAssemblyManager
    {
        private List<Assembly> _allAssemblies = null;

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
                var webProjectPath = GetParentDirectory(fullPathToTheWebProject, webprojectName);
                foreach (string dll in Directory.GetFiles(webProjectPath, "*.dll", SearchOption.AllDirectories))
                {
                    _allAssemblies.Add(Assembly.LoadFile(dll));
                }
            }

            return _allAssemblies;
        }

        /// <summary>
        /// Zum Ermitteln des Hauptpfades des Webprojektes
        /// </summary>
        private string GetParentDirectory(string path, string pathNameToFind)
        {
            if (!path.Contains(pathNameToFind))
            {
                throw new Exception("The 'WebProjectPath' was not found, because the WebProjectName was wrong.");
            }

            if (string.IsNullOrEmpty(path) || path.TrimEnd(System.IO.Path.DirectorySeparatorChar).EndsWith(pathNameToFind))
                return path;

            string parent = System.IO.Path.GetDirectoryName(path);

            if (path.Contains(pathNameToFind))
                return GetParentDirectory(parent, pathNameToFind);

            return parent;
        }
    }
}
