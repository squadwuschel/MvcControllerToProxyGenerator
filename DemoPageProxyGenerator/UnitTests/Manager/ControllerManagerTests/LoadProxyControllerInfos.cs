using System;
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

namespace UnitTests.Manager.ControllerManagerTests
{
    [TestFixture]
    public class LoadProxyControllerInfos
    {
        #region Member
        private List<Type> ControllerWithProxyAttributes { get; set; }
        private Mock<IProxyGeneratorFactoryManager> MockFactory { get; set; }
        private Mock<IMethodManager>  MockMethodManager { get; set; }
        private Mock<IProxyBuilderHelper> MockProxyBuildHelper { get; set; }
        private ControllerManager ControllerManager { get; set; }
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            MockFactory = new Mock<IProxyGeneratorFactoryManager>(); 
            MockMethodManager = new Mock<IMethodManager>();
            MockProxyBuildHelper = new Mock<IProxyBuilderHelper>();
            ControllerManager = new ControllerManager(MockFactory.Object);   
        }
        #endregion

        #region Public Tests
        [Test]
        public void Load_AngularTsProxies()
        {
            //Arrange
            ControllerWithProxyAttributes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.Contains("LoadProxyControllerInfosController")).ToList();

            MockMethodManager.Setup(p => p.LoadMethodInfos(It.IsAny<Type>(), It.IsAny<Type>())).Returns(new List<ProxyMethodInfos>());
            MockFactory.Setup(p => p.CreateMethodManager()).Returns(MockMethodManager.Object);
            MockProxyBuildHelper.Setup(p => p.GetClearControllerName(It.IsAny<Type>())).Returns("TEST");
            MockFactory.Setup(p => p.CreateProxyBuilderHelper()).Returns(MockProxyBuildHelper.Object);

            //Act
            var entries = ControllerManager.LoadProxyControllerInfos(typeof (CreateAngularTsProxyAttribute), ControllerWithProxyAttributes);

            //Assert
            Assert.AreEqual(entries.Count, 2);
            MockMethodManager.Verify(p => p.LoadMethodInfos(It.IsAny<Type>(), It.IsAny<Type>()), () => Times.Exactly(2));
            MockFactory.Verify(p => p.CreateMethodManager(), () => Times.Exactly(2));
            MockProxyBuildHelper.Verify(p => p.GetClearControllerName(It.IsAny<Type>()), () => Times.Exactly(2));
            MockFactory.Verify(p => p.CreateProxyBuilderHelper(), () => Times.Exactly(2));
        }
        #endregion

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadProxyControllerInfosControllerOne
        {
            [CreateAngularTsProxy()]
            public void OneParam(string name) { }
            [CreateAngularJsProxy()]
            public void OneComplexParam(Person person) { }
            [CreateAngularTsProxy()]
            public void OneComplexParamHttpPost(Person person) { }
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadProxyControllerInfosControllerTwo
        {
            [CreateAngularTsProxy()]
            public void TwoParams(string name, int age) { }
            [CreateAngularJsProxy()]
            public void OneComplexParamAndOneSimple(Person person, string name) { }
        }

        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadProxyControllerInfosControllerThree
        {
            [CreateJQueryTsProxy()]
            public void TwoParams(string name, int age) { }
            [CreateJQueryJsProxy()]
            public void OneComplexParamAndOneSimple(Person person, string name) { }
        }
    }
}
