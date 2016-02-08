using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class GetFunctionParameters
    {
        private Type TestClassType { get; set; }
        private ProxyBuilderHelper ProxyBuildHelper { get; set; }

        [SetUp]
        public void Setup()
        {
            //Aus der Aktuellen Test DLL DEN Typen ermitteln in dem der Name "GetFunctionParametersOneParam" vorkommt, sollte nur einen Typen geben!
            //Achtung Private "Sub" Klasse!
            TestClassType = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("GetFunctionParametersOneParam"));
            ProxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());
        }

        [Test]
        public void No_Param()
        {
            //Arrange
            var method = TestClassType.GetMethod("NoParam");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "");
        }

        [Test]
        public void One_Simple_Param()
        {
            //Arrange
            var method = TestClassType.GetMethod("OneParam");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "name");
        }

        [Test]
        public void Two_Simple_Params()
        {
            //Arrange
            var method = TestClassType.GetMethod("TwoSimpleParams");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "name,alter");
        }


        [Test]
        public void Three_Simple_Params()
        {
            //Arrange
            var method = TestClassType.GetMethod("ThreeSimpleParams");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "name,alter,aktiv");
        }

        [Test]
        public void One_Complex_Param()
        {
            //Arrange
            var method = TestClassType.GetMethod("OneComplexParam");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "person");
        }

        [Test]
        public void One_Complex_Param_And_Two_Simple_Params()
        {
            //Arrange
            var method = TestClassType.GetMethod("OneComplexParamAndTwoSimple");

            //Act
            var paramString = ProxyBuildHelper.GetFunctionParameters(method);

            //Assert
            Assert.AreEqual(paramString, "person,datum,name");
        }


        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class GetFunctionParametersOneParam
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
