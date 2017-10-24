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
            //Wir legen den AssemblyResolver fest, der sich darum kümmert, das die Richtigen AssemblyVersionen manuell nachgeladen werden
            //da wir jetzt "ReflectionOnlyLoadFrom" verwenden, wird dieser Handler benötigt um die Abhängigkeiten "manuell" nachzuladen.
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
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
                        //Wir nutzen kein Assembly.Load(dll) mehr, da wir auch 64 Bit DLLs laden wollen in einem 32 Bit Prozess. Denn die T4 Template Exe ist eine 32Bit Datei. 
                        //Daher müssen wir Assembly.ReflectionOnlyLoadFrom(dll) verwenden. ACHTUNG damit kann man kein "GetCustomAttributes" mehr verwenden, sondern muss
                        //"GetCustomAttributesData" verwenden um z.B. die passenden Attribute zu laden.
                        _allAssemblies.Add(Assembly.ReflectionOnlyLoadFrom(dll));
                    }
                    catch (Exception exception)
                    {
                        Factory.GetLogManager().AddMessage($"Fehler beim Laden der Assembly '{dll}'", exception.ToString());

                        if (exception is ReflectionTypeLoadException)
                        {
                            var typeLoadException = exception as ReflectionTypeLoadException;
                            var loaderExceptions = typeLoadException.LoaderExceptions;

                            loaderExceptions?.ToList().ForEach(p =>
                            {
                                Factory.GetLogManager().AddMessage(p.Message, String.Empty);
                            });
                        }
                    }
                }
            }

            return _allAssemblies;
        }

        //Die bereits geladenen Assemblies legen wir in einer lokalen Liste ab.
        private static List<Assembly> _loadedAssemblies = new List<Assembly>();

        /// <summary>
        /// Dependency Resolver für die Assemblies die geladen werden sollen. Da wir auch 64Bit Assemblies laden wollen in einem 32 Bit Prozess,
        /// müssen wir die Verweise "Manuell" auflösen.
        /// </summary>
        public static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                //Der Name der Assembly die wir nachladen müssen, da diese als verweis benötigt wird.
                var assemblyFromTxt = new AssemblyName(args.Name);
                //Wir ermitteln das aktuelle Arbeitsverzeichnis der anfragenden Assembly im besten Fall handelt es sich 
                //um das "bin" Directory der Anwendung.
                var currentDir = Path.GetDirectoryName(args.RequestingAssembly.Location);
                if (currentDir != null)
                {
                    //wir bauen den Pfad zur Assembly zusammen die wir auflösen sollen.
                    //und prüfen ob die Datei evtl. im aktuellen "bin" verzeichnis bereits existiert, dann wird diese
                    //Datei als Abhängigkeit zurückgegeben und wir ignorieren damit die Assembly Redirects in der App.Config/Web.Config
                    var pathWithDll = Path.Combine(currentDir, $"{assemblyFromTxt.Name}.dll");
                    if (File.Exists(pathWithDll))
                    {
                        //Aus Performancegründen die Dateien aus dem 
                        if (_loadedAssemblies.All(p => p.FullName != assemblyFromTxt.FullName))
                        {
                            var existingAssembly = Assembly.ReflectionOnlyLoadFrom(pathWithDll);
                            _loadedAssemblies.Add(existingAssembly);
                        }
                    }
                }
                else if (_loadedAssemblies.All(p => p.FullName != assemblyFromTxt.FullName))
                {
                    //Wenn es sich um eine Assembly Handelt, die wir nicht im lokalen "bin" Verzeichnis finden konnten
                    //dann soll die Datei im GAC gesucht werden.
                    var name = System.AppDomain.CurrentDomain.ApplyPolicy(args.Name);
                    _loadedAssemblies.Add(Assembly.ReflectionOnlyLoad(name));
                }

                return _loadedAssemblies.FirstOrDefault(p => p.FullName == assemblyFromTxt.FullName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
