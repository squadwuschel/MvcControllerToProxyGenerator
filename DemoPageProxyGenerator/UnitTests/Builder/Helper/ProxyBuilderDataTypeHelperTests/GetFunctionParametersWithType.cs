using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Builder.Helper.ProxyBuilderDataTypeHelperTests
{
    [TestFixture]
    public class GetFunctionParametersWithType
    {
        private List<Type> TestClassTypes { get; set; }

        [SetUp]
        public void Setup()
        {
            //Aus der Aktuellen Test DLL alle Typen ermitteln in denen der Name "GetFunctionParametersWithTypeOneParam" vorkommt, sollte nur einen Typen geben!
            //Achtung Private "Sub" Klasse!
            TestClassTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.Contains("GetFunctionParametersWithTypeOneParam")).ToList();
        }

        [Test]
        public void GetFunctionParametersWithType_OneParam()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "OneParam");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("name: string", result);
        }

        [Test]
        public void GetFunctionParametersWithType_NoParam()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "NoParam");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void GetFunctionParametersWithType_TwoSimpleParam()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "TwoSimpleParams");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("name: string,alter: number", result);
        }

        [Test]
        public void GetFunctionParametersWithType_ThreeSimpleParam()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "ThreeSimpleParams");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("name: string,alter: number,aktiv: boolean", result);
        }

        [Test]
        public void GetFunctionParametersWithType_OneComplexParam()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "OneComplexParam");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("person: UnitTests.TestHelper.TestClasses.IPerson", result);
        }

        [Test]
        public void GetFunctionParametersWithType_OneComplexParamAndTwoSimple()
        {
            //Arrange
            //Da es nur eine Klasse gibt Single verwenden und die Methode mit dem übergebenen Namen suchen.
            var methods = TestClassTypes.Single().GetMethods().FirstOrDefault(p => p.Name == "OneComplexParamAndTwoSimple");

            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act
            var result = proxyBuilderDataType.GetFunctionParametersWithType(methods);

            //Assert
            Assert.AreEqual("person: UnitTests.TestHelper.TestClasses.IPerson,datum: any,name: string", result);
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class GetFunctionParametersWithTypeOneParam
        {
            public void NoParam() { }
            public void OneParam(string name) { }
            public void TwoSimpleParams(string name, int alter) { }
            public void ThreeSimpleParams(string name, int alter, bool aktiv) { }
            public void OneComplexParam(Person person) { }
            public void OneComplexParamAndTwoSimple(Person person, DateTime datum, string name) { }
        }
    }
}
