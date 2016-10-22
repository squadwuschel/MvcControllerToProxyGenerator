using System;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Enums;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using UnitTests.TestHelper;

namespace UnitTests.Builder.AngularJsProxyBuilderTests
{
    [TestFixture]
    public class BuildProxy
    {
        //ACHTUNG die Strings müssem ganz links losgehen, da sonst sehr viele Leerzeichen im Template enthalten sind!
        private const string AngularJsModuleTemplate = @"function #ServiceName#($http) {{ this.http = $http; }}
#PrototypeServiceCalls#
angular.module('#ServiceName#', []) .service('#ServiceName#', ['$http', #ServiceName#])

";

        //ACHTUNG die Strings müssem ganz links losgehen, da sonst sehr viele Leerzeichen im Template enthalten sind!
        private const string AngularJsPrototype = @"#ServiceName#.prototype.#ControllerFunctionName# = function (#ServiceParamters#) {{
return this.http.#ServiceCallAndParameters#.then(function (result) {{ return result.data; }}); }}

";

        private const string CompleteTemplateForAssert = @"function homePSrv($http) {{ this.http = $http; }}
homePSrv.prototype.OneParam = function (name) {{
return this.http.get('Home/OneParam'+ '?name='+encodeURIComponent(name)).then(function (result) {{ return result.data; }}); }}

homePSrv.prototype.OneComplexParam = function (name) {{
return this.http.get('Home/OneParam'+ '?name='+encodeURIComponent(name)).then(function (result) {{ return result.data; }}); }}


angular.module('homePSrv', []) .service('homePSrv', ['$http', homePSrv])";


        private const string AngularJsWindowLocationHref = "public #ControllerFunctionName#(#ServiceParamters#) : void  { \r\n    window.location.href = #ServiceCallAndParameters#; \r\n } \r\n\r\n";


        private Mock<IProxyGeneratorFactoryManager> MockFactory { get; set; }
        private Mock<IProxyBuilderHelper> MockBuildHelper { get; set; }
        private Mock<IProxyBuilderHttpCall> MockBuildHelperHttpCall { get; set; }
        private Mock<ISettingsManager> MockSettingsManager { get; set; }

        private AngularJsProxyBuilder AngularJsProxyBuilder { get; set; }

        [SetUp]
        public void Setup()
        {
            //Init
            MockFactory = new Mock<IProxyGeneratorFactoryManager>();
            MockBuildHelper = new Mock<IProxyBuilderHelper>();
            MockBuildHelperHttpCall = new Mock<IProxyBuilderHttpCall>();
            MockSettingsManager = new Mock<ISettingsManager>();

            //Arrange ProxySettings
            var proxySettings = new ProxySettings();
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsModule, Template = AngularJsModuleTemplate, TemplateSuffix = "PSrv" });
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsPrototype, Template = AngularJsPrototype });
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsWindowLocationHref, Template = AngularJsWindowLocationHref });
            MockFactory.Setup(p => p.GetProxySettings()).Returns(proxySettings);

            //Unsere Mockobjekte zuweisen
            AngularJsProxyBuilder = new AngularJsProxyBuilder(MockFactory.Object);
            AngularJsProxyBuilder.ProxyBuilderHelper = MockBuildHelper.Object;
            AngularJsProxyBuilder.ProxyBuilderHttpCall = MockBuildHelperHttpCall.Object;
            AngularJsProxyBuilder.SettingsManager = MockSettingsManager.Object;
        }

        [Test]
        public void Success()
        {
            //Arrange
            var controllerInfos = new ProxyControllerInfoGenerator().GetControllerInfos();

            MockBuildHelper.Setup(p => p.GetServiceName("Home", "PSrv", true)).Returns("homePSrv");
            MockBuildHelper.Setup(p => p.GetProxyFunctionName("OneParam")).Returns("OneParam");
            MockBuildHelper.Setup(p => p.GetProxyFunctionName("OneComplexParam")).Returns("OneComplexParam");

            MockBuildHelper.Setup(p => p.GetFunctionParameters(It.IsAny<MethodInfo>())).Returns("name");
            MockBuildHelperHttpCall.Setup(p => p.BuildHttpCall(It.IsAny<ProxyMethodInfos>(), It.IsAny<ProxyBuilder>())).Returns("get('Home/OneParam'+ '?name='+encodeURIComponent(name))");

            //Act
            var generatedProxyEntries = AngularJsProxyBuilder.BuildProxy(controllerInfos);


            //Assert
            Assert.AreEqual(generatedProxyEntries[0].FileContent.Trim(), CompleteTemplateForAssert.Trim());
            //Achtung der Unit Test prüft nur ob die Funktionen entsprechend oft aufgerufen wurden, aber nicht ob das Ergebnis 
            //"richtig" stimmt, die geschieht bereits durch andere Unit Tests
            MockBuildHelper.Verify(p => p.GetServiceName("Home", "PSrv", true), () => Times.Exactly(3));
            MockBuildHelper.Verify(p => p.GetProxyFunctionName("OneParam"), () => Times.Exactly(1));
            MockBuildHelper.Verify(p => p.GetProxyFunctionName("OneComplexParam"), () => Times.Exactly(1));
            MockBuildHelper.Verify(p => p.GetFunctionParameters(It.IsAny<MethodInfo>()), () => Times.Exactly(2));
            MockBuildHelperHttpCall.Verify(p => p.BuildHttpCall(It.IsAny<ProxyMethodInfos>(), It.IsAny<ProxyBuilder>()), () => Times.Exactly(2));
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Please add the 'AngularJsModule' Template when you want to create a AngularJs Proxy")]
        public void TemplateType_AngularJsModule_Not_Found()
        {
            //Arrange
            AutoMocker mocker = new AutoMocker();
            var proxySettings = new ProxySettings();
            mocker.Use<IProxyGeneratorFactoryManager>(new ProxyGeneratorFactoryManager(proxySettings));
            var myMock = mocker.CreateInstance<AngularJsProxyBuilder>();

            //Act
            var generatedProxyEntries = myMock.BuildProxy(new List<ProxyControllerInfo>());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Please add the 'AngularJsPrototype' Template when you want to create a AngularJs Proxy")]
        public void TemplateType_AngularJsPrototype_Not_Found()
        {
            //Arrange
            AutoMocker mocker = new AutoMocker();
            var proxySettings = new ProxySettings();
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsModule });

            mocker.Use<IProxyGeneratorFactoryManager>(new ProxyGeneratorFactoryManager(proxySettings));
            var myMock = mocker.CreateInstance<AngularJsProxyBuilder>();

            //Act
            var generatedProxyEntries = myMock.BuildProxy(new List<ProxyControllerInfo>());
        }


    }
}
