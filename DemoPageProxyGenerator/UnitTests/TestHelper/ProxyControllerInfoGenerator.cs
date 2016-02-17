using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using ProxyGenerator.Container;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.TestHelper
{
    /// <summary>
    /// Helper Klasse, welche für die ProxyBuilder Tests eine Liste mit passenden ProxyControllerInfos erstellt.
    /// Für jeden ProxyBuilder wird die gleiche Liste verwendet!
    /// </summary>
    public class ProxyControllerInfoGenerator
    {
        private List<Type> TestClassTypes { get; set; }

        public ProxyControllerInfoGenerator()
        {
            //Aus der Aktuellen Test DLL alle Typen ermitteln in denen der Name "ProxyControllerInfoGeneratorOneParam" vorkommt, sollte nur einen Typen geben!
            //Achtung Private "Sub" Klasse!
            TestClassTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.Contains("ProxyControllerInfoGeneratorOneParam")).ToList();
        }

        /// <summary>
        /// Eine Liste mit ControllerInfos zurückgeben. Achtung wenn hier Daten geändert werden, kann dies eine Menge Testfälle betreffen.
        /// </summary>
        public List<ProxyControllerInfo> GetControllerInfos()
        {
            var proxyMethodInfos = new List<ProxyMethodInfos>();
            proxyMethodInfos.Add(new ProxyMethodInfos() { MethodInfo = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "OneParam") });
            proxyMethodInfos.Add(new ProxyMethodInfos() { MethodInfo = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "OneComplexParam") });

            var proxyControllerInfos = new List<ProxyControllerInfo>();
            proxyControllerInfos.Add(new ProxyControllerInfo()
            {
                ProxyMethodInfos = proxyMethodInfos,
                ControllerNameWithoutSuffix = "Home"
            });

            return proxyControllerInfos;
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class ProxyControllerInfoGeneratorOneParam
        {
            public void OneParam(string name) { }
            public void OneComplexParam(Person person) { }
        }

    }
}
