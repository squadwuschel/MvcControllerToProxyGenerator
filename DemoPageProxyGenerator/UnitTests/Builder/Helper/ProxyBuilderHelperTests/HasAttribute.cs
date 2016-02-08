using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using ProxyGenerator.ProxyTypeAttributes;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class HasAttribute
    {
        private Type TestClassType { get; set; }
        private ProxyBuilderHelper ProxyBuildHelper { get; set; }

        [SetUp]
        public void Setup()
        {
            //Aus der Aktuellen Test DLL DEN Typen ermitteln in dem der Name "GetFunctionParametersOneParam" vorkommt, sollte nur einen Typen geben!
            //Achtung Private "Sub" Klasse!
            TestClassType = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("HasAttributeOneParam"));
            ProxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());
        }

        [Test]
        public void CreateAngularJsProxy_HasAttribute_True()
        {
            //Arrange
            var method = TestClassType.GetMethod("NoParam");

            //Act
            var hasAttribute = ProxyBuildHelper.HasAttribute(typeof (CreateAngularJsProxyAttribute), method);

            //Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void CreateAngularJsProxy_HasAttribute_False()
        {
            //Arrange
            var method = TestClassType.GetMethod("NoParam");

            //Act
            var hasAttribute = ProxyBuildHelper.HasAttribute(typeof(CreateJQueryTsProxyAttribute), method);

            //Assert
            Assert.IsFalse(hasAttribute);
        }

        [Test]
        public void CreateAngularTsProxy_HasAttribute_True()
        {
            //Arrange
            var method = TestClassType.GetMethod("OneParam");

            //Act
            var hasAttribute = ProxyBuildHelper.HasAttribute(typeof(CreateAngularTsProxyAttribute), method);

            //Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void CreateAngularTsProxy_HasAttribute_False()
        {
            //Arrange
            var method = TestClassType.GetMethod("OneParam");

            //Act
            var hasAttribute = ProxyBuildHelper.HasAttribute(typeof(CreateJQueryTsProxyAttribute), method);

            //Assert
            Assert.IsFalse(hasAttribute);
        }


        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class HasAttributeOneParam
        {
            [CreateAngularJsProxy]
            public void NoParam() { }

            [CreateAngularTsProxy]
            public void OneParam(string name) { }
        }
    }
}
