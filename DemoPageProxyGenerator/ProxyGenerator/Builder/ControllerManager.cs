using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TextTemplating;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Builder
{
    public class ControllerManager
    {

        /// <summary>
        /// Alle Controller ermitteln die für das Projekt befunden werden können.
        /// </summary>
        public List<Type> GetAllController(string webprojectName, ITextTemplatingEngineHost host)
        {
            //Den Pfad zum T4 Template ermitteln
            var fullPathToT4Template = System.IO.Path.GetFullPath(host.TemplateFile);
            var webProjectPath = GetParentDirectory(fullPathToT4Template, webprojectName);

            List<Assembly> allAssemblies = new List<Assembly>();

            foreach (string dll in Directory.GetFiles(webProjectPath, "*.dll", SearchOption.AllDirectories))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }


            List<Type> allController = new List<Type>();
            foreach (Assembly assembly in allAssemblies)
            {
                try
                {
                    //Nur die Assemblies heraussuchen in denen unser BasisAttribut für die Proxy Erstellung gesetzt wurde.
                    var types = assembly.GetTypes().Where(type => type.GetMethods().Any(p => p.GetCustomAttributes(typeof (CreateProxyBaseAttribute), true).Any())).ToList();

                    foreach (Type type in types)
                    {
                        //Prüfen das jede Klasse (Controller) nur einmal unserer Liste hinzugefügt wird.
                        if (allController.All(p => p.AssemblyQualifiedName != type.AssemblyQualifiedName))
                        {
                            allController.Add(type);
                        }
                    }
                }
                catch(Exception exception)
                {
                    Trace.WriteLine("Fehler beim Auslesen der Assemblies: " + exception.Message);
                }
            }

            return allController;
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
