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

        /// <summary>
        /// Das aktuelle Verzeichnis in dem sich die Anwendung befindet
        /// </summary>
        private static string _appDirectory = "";

        /// <summary>
        /// Wir legen uns eine Liste mit Dateien an, die sich im aktuellen Verzeichnis befinden.
        /// Denn durch die Umstellung auf ReflectionOnlyLoadFrom, gibt es diverse Probleme das alle Dateien auch im
        /// "Live Modus" nicht Debugmodus finden. Denn im "Live Modus" handelt es sich teilweise beim Afragen "args.RequestingAssembly.Location"
        /// um das Tempverzeichnis für .NET DLLs und das macht nur Probleme beim Laden der richtigen DLL Versionen.
        /// </summary>
        private static List<string> _allFiles = new List<string>();

        private static bool _writeLog = false;

        IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public AssemblyManager(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            //Wir legen den AssemblyResolver fest, der sich darum kümmert, das die Richtigen AssemblyVersionen manuell nachgeladen werden
            //da wir jetzt "ReflectionOnlyLoadFrom" verwenden, wird dieser Handler benötigt um die Abhängigkeiten "manuell" nachzuladen.
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
            Factory = proxyGeneratorFactory;
            _writeLog = Factory.GetLogManager().WriteLog;
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

                //Den Pfad zur Webseite ermitteln unter der wir dann alle DLLs ermitteln und durchgehen.
                _appDirectory = Factory.FileHelper().GetParentDirectory(fullPathToTheWebProject, webprojectName);
                LogManager.Log(_writeLog, "APPDIRECTORY ", _appDirectory);
                LogManager.Log(_writeLog, "ALLFILES ",string.Join(", \r\n", GetAllDlls()));

                foreach (string dll in GetAllDlls())
                {
                    try
                    {
                        LogManager.Log(_writeLog, "ASSEMBLY LOADING ", dll);
                        
                        //Wir nutzen kein Assembly.Load(dll) mehr, da wir auch 64 Bit DLLs laden wollen in einem 32 Bit Prozess. Denn die T4 Template Exe ist eine 32Bit Datei. 
                        //Daher müssen wir Assembly.ReflectionOnlyLoadFrom(dll) verwenden. ACHTUNG damit kann man kein "GetCustomAttributes" mehr verwenden, sondern muss
                        //"GetCustomAttributesData" verwenden um z.B. die passenden Attribute zu laden.
                        _allAssemblies.Add(Assembly.ReflectionOnlyLoadFrom(dll));
                        LogManager.Log(_writeLog, "OK ", dll);
                    }
                    catch (Exception exception)
                    {
                        Factory.GetLogManager().AddMessage($"Fehler beim Laden der Assembly '{dll}'", exception.ToString());
                        LogManager.Log(_writeLog, "****EX****", exception.ToString());

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
                LogManager.Log(_writeLog, $"RESOLVE '{args.Name}' location '{args.RequestingAssembly.Location}'");
                //Der Name der Assembly die wir nachladen müssen, da diese als verweis benötigt wird.
                var assemblyFromTxt = new AssemblyName(args.Name);

                //wir ermitteln das Verzeichnis wo die DLL im besten fall liegt in unserem Projektverzeichnis, wir können nicht auf "args.RequestingAssembly.Location"
                //setzen, da hier meist das Temporäre .NET Verzeichnis für zurückgegeben wird und wir evtl. eine falsche/andere Version erhalten.
                var fileDirectory = GetFilePath(assemblyFromTxt.Name);
                if (!string.IsNullOrEmpty(fileDirectory))
                {
                    //wir bauen den Pfad zur Assembly zusammen die wir auflösen sollen.
                    //und prüfen ob die Datei evtl. im aktuellen "bin" verzeichnis bereits existiert, dann wird diese
                    //Datei als Abhängigkeit zurückgegeben und wir ignorieren damit die Assembly Redirects in der App.Config/Web.Config
                    var pathWithDll = Path.Combine(fileDirectory, $"{assemblyFromTxt.Name}.dll");
                    if (File.Exists(pathWithDll))
                    {
                        //Aus Performancegründen die Dateien aus dem 
                        if (_loadedAssemblies.All(p => p.GetName().Name != assemblyFromTxt.Name))
                        {
                            var existingAssembly = Assembly.ReflectionOnlyLoadFrom(pathWithDll);
                            _loadedAssemblies.Add(existingAssembly);
                            LogManager.Log(_writeLog, "RESOLVE ", "add-path", pathWithDll);
                        }
                        return _loadedAssemblies.First(p => p.GetName().Name == assemblyFromTxt.Name);
                    }
                }

                if (_loadedAssemblies.All(p => p.GetName().Name != assemblyFromTxt.Name))
                {
                    //Wenn es sich um eine Assembly Handelt, die wir nicht im lokalen "bin" Verzeichnis finden konnten
                    //dann soll die Datei im GAC gesucht werden.
                    var name = System.AppDomain.CurrentDomain.ApplyPolicy(args.Name);
                    _loadedAssemblies.Add(Assembly.ReflectionOnlyLoad(name));
                    LogManager.Log(_writeLog, "RESOLVE ", "add-path", name);
                }

                return _loadedAssemblies.First(p => p.GetName().Name == assemblyFromTxt.Name);
            }
            catch (Exception exception)
            {
                LogManager.Log(_writeLog, "****EX CurrentDomain_ReflectionOnlyAssemblyResolve****", "RESOLVE ", exception.ToString());
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Gibt alle DLLs zurück, die sich im Programmverzeichnis befinden. Außer das \obj\ Verzeichnis wird nicht mit ausgewertet.
        /// Da es sonst nur Probleme mit Doppelten DLLs gibt.
        /// </summary>
        private static List<string> GetAllDlls()
        {
            if (_allFiles.Count > 0) return _allFiles;

            var allUnfilteredFiles = Directory.GetFiles(_appDirectory, "*.dll", SearchOption.AllDirectories);
            foreach (var file in allUnfilteredFiles)
            {
                //Da wir alle Pfade durchgehen, müssen wir die obj Pfade weglassen, da es sonst zu Problemen kommt.
                if (file.Contains(@"\obj\"))
                {
                    continue;
                }

                _allFiles.Add(file);
            }

            return _allFiles;
        }

        /// <summary>
        /// Wir suchen die übergebene Datei im FilePfad den wir übergeben bekommen und geben das erste Ergebnis zurück wo wir diese Datei finden.
        /// </summary>
        /// <param name="filename">Der Name der Datei OHNE dll am ende</param>
        private static string GetFilePath(string filename)
        {
            filename = $"{filename}.dll";

            foreach (var file in _allFiles)
            {
                if (file.Contains(filename))
                {
                    return Path.GetDirectoryName(file);
                }
            }

            return null;
        }
    }
}
