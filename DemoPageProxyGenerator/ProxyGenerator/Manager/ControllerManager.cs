using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ProxyGenerator.Interfaces;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Manager
{
    public class ControllerManager : IControllerManager
    {
        /// <summary>
        /// Alle Controller ermitteln die für das Projekt befunden werden können.
        /// </summary>
        public List<Type> GetAllProxyController(List<Assembly> assemblies)
        {
            List<Type> allController = new List<Type>();
            foreach (Assembly assembly in assemblies)
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
    }
}
