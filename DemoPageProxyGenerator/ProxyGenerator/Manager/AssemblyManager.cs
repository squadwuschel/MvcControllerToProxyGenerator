using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class AssemblyManager : IAssemblyManager
    {
        /// <summary>
        /// Laden der Assemblies die überprüft werden müssen, ob diese das Attribut zum Erstellen eines Proxies enthalten.
        /// </summary>
        /// <param name="webprojectName">Der Name des WebProjektes in dem wir die Assemblies laden</param>
        /// <param name="host">Der T4 Host, über den der Aktuelle Pfad ermittelt wird</param>
        public List<Assembly> LoadAssemblies(string webprojectName, ITextTemplatingEngineHost host)
        {
            //Den Pfad zum T4 Template ermitteln
            var fullPathToT4Template = System.IO.Path.GetFullPath(host.TemplateFile);
            var webProjectPath = GetParentDirectory(fullPathToT4Template, webprojectName);

            List<Assembly> allAssemblies = new List<Assembly>();

            foreach (string dll in Directory.GetFiles(webProjectPath, "*.dll", SearchOption.AllDirectories))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }

            return allAssemblies;
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
