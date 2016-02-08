using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class GetProxyFileName
    {
        [Test]
        public void TypeScriptFile_Extensions()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("Home", "PSrv", "ts");

            //Assert
            Assert.AreEqual(name, "homePSrv.ts");
        }

        [Test]
        public void JavaScriptFile_Extensions()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("Home", "PSrv", "js");

            //Assert
            Assert.AreEqual(name, "homePSrv.js");
        }

        [Test]
        public void ControllerName_One_Letter()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("H", "PSrv", "js");

            //Assert
            Assert.AreEqual(name, "hPSrv.js");
        }

        [Test]
        public void ControllerName_Two_Letters()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("Ho", "PSrv", "js");

            //Assert
            Assert.AreEqual(name, "hoPSrv.js");
        }

        [Test]
        public void Suffix_IsNull()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("home", null, "js");

            //Assert
            Assert.AreEqual(name, "home.js");
        }

        [Test]
        public void Suffix_Empty()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings());

            //Act 
            var name = proxyBuilder.GetProxyFileName("home", string.Empty, "js");

            //Assert
            Assert.AreEqual(name, "home.js");
        }

    }
}