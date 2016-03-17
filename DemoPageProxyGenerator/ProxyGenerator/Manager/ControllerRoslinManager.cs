using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGenerator.Manager
{
    public class ControllerRoslinManager : IControllerManager
    {
        #region Member
        IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public ControllerRoslinManager(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
        }
        #endregion  

        #region Public Functions
        /// <summary>
        /// Laden aller Methoden und Parameterinformationen in allen Klassen (Controllern) in denen das übergebene ProxyType Attribut verwendet wird.
        /// </summary>
        public List<ProxyControllerInfo> LoadProxyControllerInfos(Type proxyTypeAttribute, List<Type> allController)
        {
            List<ProxyControllerInfo> proxyControllerInfos = new List<ProxyControllerInfo>();
            //Nur die Controller laden in denen auch unser Attribut verwendet wird für das wir die Informationen ermitteln sollen.
            var typedController = GetProxyControllerByProxyTypeAttribute(proxyTypeAttribute, allController);

            typedController.ForEach(p =>
            {
                ProxyControllerInfo proxyControllerInfo = new ProxyControllerInfo();
                //Laden der MethodenInformationen zu unserem Controller und nur die Methoden laden bei denen auch das passende Attribut darüber steht.
                proxyControllerInfo.ProxyMethodInfos = Factory.CreateMethodManager().LoadMethodInfos(p, proxyTypeAttribute);
                proxyControllerInfo.Controller = p;
                proxyControllerInfo.ControllerNameWithoutSuffix = Factory.CreateProxyBuilderHelper().GetClearControllerName(p);
                proxyControllerInfos.Add(proxyControllerInfo);
            });

            return proxyControllerInfos;
        }

        /// <summary>
        /// Alle Controller ermitteln die für das Projekt befunden werden können.
        /// </summary>
        public List<Type> GetAllProjectProxyController(ProxySettings proxySettings)
        {
            List<Type> allController = new List<Type>();

            var settings = Factory.GetProxySettings();
            var webProjectPath = Factory.FileHelper().GetParentDirectory(settings.FullPathToTheWebProject, settings.WebProjectName) + @"\Controllers\";
            var files = Directory.EnumerateFiles(webProjectPath, "*.cs", SearchOption.AllDirectories);

            foreach (CSharpSyntaxTree syntaxTree in files.Select(p => CSharpSyntaxTree.ParseText(File.ReadAllText(p))).Cast<CSharpSyntaxTree>())
            {
                var ctrl = syntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();

                SyntaxFactory.ParseArgumentList("").


            }

            //Alle Assemblies im aktuellen Projekt laden.
            //var assemblies = Factory.CreateAssemblyManager().LoadAssemblies(proxySettings.WebProjectName, proxySettings.FullPathToTheWebProject);

            //foreach (Assembly assembly in assemblies)
            //{
            //    try
            //    {
            //        //Nur die Assemblies heraussuchen in denen unser BasisAttribut für die Proxy Erstellung gesetzt wurde.
            //        var types = assembly.GetTypes().Where(type => type.GetMethods().Any(p => p.GetCustomAttributes(typeof(CreateProxyBaseAttribute), true).Any())).ToList();

            //        foreach (Type type in types)
            //        {
            //            //Prüfen das jede Klasse (Controller) nur einmal unserer Liste hinzugefügt wird.
            //            if (allController.All(p => p.AssemblyQualifiedName != type.AssemblyQualifiedName))
            //            {
            //                allController.Add(type);
            //            }
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        Trace.WriteLine("Fehler beim Auslesen der Assemblies: " + exception.Message);
            //    }
            //}

            return allController;
        }

        /// <summary>
        /// Die Liste an Controllern ermitteln in denen das übergebene ProxyTypeAttribute gesetzt wurde.
        /// </summary>
        public List<Type> GetProxyControllerByProxyTypeAttribute(Type proxyTypeAttribute, List<Type> allController)
        {
            return allController.Where(type => type.GetMethods().Any(p => p.GetCustomAttributes(true).Any(attr => attr.GetType() == proxyTypeAttribute))).ToList();
        }
        #endregion
    }
}
