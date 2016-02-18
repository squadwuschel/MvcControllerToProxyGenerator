using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using NUnit.Framework;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using ProxyGenerator.ProxyTypeAttributes;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Manager.MethodManagerTests
{
    [TestFixture]
    public class LoadMethodInfos
    {
        #region Member
        private Mock<IProxyGeneratorFactoryManager> MockFactory { get; set; }
        private Mock<IMethodParameterManager> MockMethodParameterManager { get; set; }
        private MethodManager MethodManager { get; set; }
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            MockFactory = new Mock<IProxyGeneratorFactoryManager>();
            MockMethodParameterManager = new Mock<IMethodParameterManager>();
            MethodManager = new MethodManager(MockFactory.Object);
        }
        #endregion

        #region Public Tests
        [Test]
        public void Success()
        {
            //Arrange
            var controllerWithMethods = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("LoadMethodInfosControllerOne"));

            MockMethodParameterManager.Setup(p => p.LoadParameterInfos(It.IsAny<MethodInfo>())).Returns(new List<ProxyMethodParameterInfo>());
            MockFactory.Setup(p => p.CreateMethodParameterManager()).Returns(MockMethodParameterManager.Object);

            //Act 
            var proxyMethodInfos = MethodManager.LoadMethodInfos(controllerWithMethods, typeof (CreateAngularTsProxyAttribute));

            //Assert
            Assert.AreEqual(proxyMethodInfos.Count, 2);
            Assert.AreEqual(proxyMethodInfos[0].MethodInfo.Name, "OneParam");
            Assert.AreEqual(proxyMethodInfos[0].ReturnType, typeof(string));
            Assert.AreEqual(proxyMethodInfos[1].MethodInfo.Name, "OneComplexParamHttpPost");
            Assert.AreEqual(proxyMethodInfos[1].ReturnType, typeof(int));
            MockMethodParameterManager.Verify(p => p.LoadParameterInfos(It.IsAny<MethodInfo>()), () => Times.Exactly(2));
            MockFactory.Verify(p => p.CreateMethodParameterManager(), () => Times.Exactly(2));
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "ERROR, JavaScript doesn't supports function/method overload, please rename one of those functions/methods 'TwoParams'")]
        public void Method_Overload_Exception()
        {
            //Arrange
            var controllerWithMethods = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("LoadMethodInfosControllerTwo"));

            //Da die Funktionen Mindestens einmal aufgerufen werden müssen diese entsprechend das Mock bereitstellen
            MockMethodParameterManager.Setup(p => p.LoadParameterInfos(It.IsAny<MethodInfo>())).Returns(new List<ProxyMethodParameterInfo>());
            MockFactory.Setup(p => p.CreateMethodParameterManager()).Returns(MockMethodParameterManager.Object);

            //Act 
            var proxyMethodInfos = MethodManager.LoadMethodInfos(controllerWithMethods, typeof(CreateAngularTsProxyAttribute));
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException), ExpectedMessage = "Please don't use Interfaces as 'ReturnType' for 'CreateProxy': 'IList' (its not supported)")]
        public void ReturnType_Interface_Exception()
        {
            //Arrange
            var controllerWithMethods = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("LoadMethodInfosControllerThree"));

            //Da die Funktionen Mindestens einmal aufgerufen werden müssen diese entsprechend das Mock bereitstellen
            MockMethodParameterManager.Setup(p => p.LoadParameterInfos(It.IsAny<MethodInfo>())).Returns(new List<ProxyMethodParameterInfo>());
            MockFactory.Setup(p => p.CreateMethodParameterManager()).Returns(MockMethodParameterManager.Object);

            //Act 
            var proxyMethodInfos = MethodManager.LoadMethodInfos(controllerWithMethods, typeof(CreateAngularTsProxyAttribute));
        }
        #endregion

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadMethodInfosControllerOne
        {
            [CreateAngularTsProxy(ReturnType = typeof(string))]
            public void OneParam(string name) { }
            [CreateAngularJsProxy()]
            public void OneComplexParam(Person person) { }
            [CreateAngularTsProxy(ReturnType = typeof(int))]
            public void OneComplexParamHttpPost(Person person) { }
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadMethodInfosControllerTwo
        {
            [CreateAngularTsProxy(ReturnType = typeof(List<int>))]
            public void TwoParams(string name, int age) { }

            [CreateAngularTsProxy(ReturnType = typeof(List<int>))]
            public void TwoParams(string name, int age, DateTime start) { }
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadMethodInfosControllerThree
        {
            [CreateAngularTsProxy(ReturnType = typeof(IList))]
            public void TwoParams(string name, int age) { }
        }
    }
}
