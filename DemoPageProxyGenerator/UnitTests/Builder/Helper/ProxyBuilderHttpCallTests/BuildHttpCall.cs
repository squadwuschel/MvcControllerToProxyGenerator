using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Builder.Helper.ProxyBuilderHttpCallTests
{
    [TestFixture]
    public class BuildHttpCall
    {
        private Type TestClassType { get; set; }
        private Mock<IProxyGeneratorFactoryManager> MockFactory { get; set; }
        private Mock<IProxyBuilderHelper> MockBuildHelper { get; set; } 

        private IProxyBuilderHttpCall ProxyBuilderHttpCall { get; set; }


        [SetUp]
        public void Setup()
        {
            //Aus der Aktuellen Test DLL DEN Typen ermitteln in dem der Name "GetFunctionParametersOneParam" vorkommt, sollte nur einen Typen geben!
            //Achtung Private "Sub" Klasse!
            TestClassType = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("BuildHttpCallOneParam"));

            MockFactory = new Mock<IProxyGeneratorFactoryManager>();
            MockBuildHelper = new Mock<IProxyBuilderHelper>();
            MockFactory.Setup(p => p.CreateProxyBuilderHelper()).Returns(MockBuildHelper.Object);
            ProxyBuilderHttpCall = new ProxyBuilderHttpCall(MockFactory.Object);
        }

        [Test]
        public void BuildGet_NoComplexType_NoId()
        {
            //Arrange
            var methodInfos = new ProxyMethodInfos();
            //Die MethodenInfos laden - können wir nicht Mocken!
            methodInfos.MethodInfo = TestClassType.GetMethod("OneParam");
            methodInfos.ProxyMethodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false});

            //Mocken der passenden Infos
            MockBuildHelper.Setup(p => p.GetClearControllerName(It.IsAny<Type>())).Returns("Home");
            MockBuildHelper.Setup(p => p.BuildUrlParameterId(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(string.Empty);
            MockBuildHelper.Setup(p => p.BuildUrlParameter(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(" + '?name='+encodeURIComponent(name)");

            //Act
            var getParams = ProxyBuilderHttpCall.BuildHttpCall(methodInfos);

            //Assert
            Assert.AreEqual(getParams, "get('Home/OneParam' + '?name='+encodeURIComponent(name))");
        }

        [Test]
        public void BuildGet_NoComplexType_WithId()
        {
            //Arrange
            var methodInfos = new ProxyMethodInfos();
            //Die MethodenInfos laden - können wir nicht Mocken!
            methodInfos.MethodInfo = TestClassType.GetMethod("OneParam");
            methodInfos.ProxyMethodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, ParameterName = "id"});

            //Mocken der passenden Infos
            MockBuildHelper.Setup(p => p.GetClearControllerName(It.IsAny<Type>())).Returns("Home");
            MockBuildHelper.Setup(p => p.BuildUrlParameterId(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(" + '/' + id ");
            MockBuildHelper.Setup(p => p.BuildUrlParameter(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(" + '?name='+encodeURIComponent(name)");

            //Act
            var getParams = ProxyBuilderHttpCall.BuildHttpCall(methodInfos);

            //Assert
            Assert.AreEqual(getParams, "get('Home/OneParam' + '/' + id  + '?name='+encodeURIComponent(name))");
        }


        [Test]
        public void BuildPost_IsComplexeType_True()
        {
            //Arrange
            var methodInfos = new ProxyMethodInfos();
            //Die MethodenInfos laden - können wir nicht Mocken!
            methodInfos.MethodInfo = TestClassType.GetMethod("OneComplexParam");
            methodInfos.ProxyMethodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = true, ParameterName = "person"});

            //Mocken der passenden Infos
            MockBuildHelper.Setup(p => p.GetClearControllerName(It.IsAny<Type>())).Returns("Home");
            MockBuildHelper.Setup(p => p.BuildUrlParameterId(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(String.Empty);
            MockBuildHelper.Setup(p => p.BuildUrlParameter(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(" + '?name='+encodeURIComponent(name)");

            //Act
            var getParams = ProxyBuilderHttpCall.BuildHttpCall(methodInfos);

            //Assert
            Assert.AreEqual(getParams, "post('Home/OneComplexParam' + '?name='+encodeURIComponent(name),person)");
        }


        [Test]
        public void BuildPost_IsComplexeType_False()
        {
            //Arrange
            var methodInfos = new ProxyMethodInfos();
            //Die MethodenInfos laden - können wir nicht Mocken!
            methodInfos.MethodInfo = TestClassType.GetMethod("OneComplexParamHttpPost");
            methodInfos.ProxyMethodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, ParameterName = "person" });

            //Mocken der passenden Infos
            MockBuildHelper.Setup(p => p.GetClearControllerName(It.IsAny<Type>())).Returns("Home");
            MockBuildHelper.Setup(p => p.BuildUrlParameterId(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(String.Empty);
            MockBuildHelper.Setup(p => p.BuildUrlParameter(It.IsAny<List<ProxyMethodParameterInfo>>())).Returns(" + '?name='+encodeURIComponent(name)");
            MockBuildHelper.Setup(p => p.HasAttribute(It.IsAny<Type>(), It.IsAny<MethodInfo>())).Returns(true);

            //Act
            var getParams = ProxyBuilderHttpCall.BuildHttpCall(methodInfos);

            //Assert
            Assert.AreEqual(getParams, "post('Home/OneComplexParamHttpPost' + '?name='+encodeURIComponent(name))");
        }


        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class BuildHttpCallOneParam
        {
            public void OneParam(string name) { }
            public void OneComplexParam(Person person) { }

            [HttpPost]
            public void OneComplexParamHttpPost(Person person) { }
        }
    }
}
