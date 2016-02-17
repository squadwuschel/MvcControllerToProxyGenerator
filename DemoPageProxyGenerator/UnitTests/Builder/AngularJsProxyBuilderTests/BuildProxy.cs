using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using ProxyGenerator.Builder;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;
using UnitTests.TestHelper;
using UnitTests.TestHelper.TestClasses;

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


        private Mock<IProxyGeneratorFactoryManager> MockFactory { get; set; }
        private Mock<IProxyBuilderHelper> MockBuildHelper { get; set; }
        private Mock<IProxyBuilderHttpCall> MockBuildHelperHttpCall { get; set; }

        private AngularJsProxyBuilder AngularJsProxyBuilder { get; set; }

        [SetUp]
        public void Setup()
        {
            //Init
            MockFactory = new Mock<IProxyGeneratorFactoryManager>();
            MockBuildHelper = new Mock<IProxyBuilderHelper>();
            MockBuildHelperHttpCall = new Mock<IProxyBuilderHttpCall>();

            //Arrange ProxySettings
            var proxySettings = new ProxySettings();
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsModule, Template = AngularJsModuleTemplate, TemplateSuffix = "PSrv" });
            proxySettings.Templates.Add(new TemplateEntry() { TemplateType = TemplateTypes.AngularJsPrototype, Template = AngularJsPrototype });
            MockFactory.Setup(p => p.GetProxySettings()).Returns(proxySettings);

            //Unsere Mockobjekte zuweisen
            AngularJsProxyBuilder = new AngularJsProxyBuilder(MockFactory.Object);
            AngularJsProxyBuilder.ProxyBuilderHelper = MockBuildHelper.Object;
            AngularJsProxyBuilder.ProxyBuilderHttpCall = MockBuildHelperHttpCall.Object;

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
            MockBuildHelperHttpCall.Setup(p => p.BuildHttpCall(It.IsAny<ProxyMethodInfos>())).Returns("get('Home/OneParam'+ '?name='+encodeURIComponent(name))");

            //Act
            var generatedProxyEntries = AngularJsProxyBuilder.BuildProxy(controllerInfos);


            //Assert
            Assert.AreEqual(generatedProxyEntries[0].FileContent.Trim(), CompleteTemplateForAssert.Trim());


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
