using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class GetServiceName
    {
        [Test]
        public void LowerFirstChar_True()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() {LowerFirstCharInFunctionName = true});

            //Act
            var name = proxyBuilder.GetServiceName("Home", "PSrv", true);

            //Assert
            Assert.AreEqual(name, "homePSrv");
        }

        [Test]
        public void LowerFirstChar_False()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = false });

            //Act
            var name = proxyBuilder.GetServiceName("Home", "PSrv", false);

            //Assert
            Assert.AreEqual(name, "HomePSrv");
        }

        [Test]
        public void ControllerName_One_CharLength_LowerFirstChar_True()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true });

            //Act
            var name = proxyBuilder.GetServiceName("H", "PSrv",true);

            //Assert
            Assert.AreEqual(name, "hPSrv");
        }

        [Test]
        public void ControllerName_One_CharLength_LowerFirstChar_False()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = false });

            //Act
            var name = proxyBuilder.GetServiceName("H", "PSrv", false);

            //Assert
            Assert.AreEqual(name, "HPSrv");
        }

        [Test]
        public void ControllerName_Two_CharLength()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true });

            //Act
            var name = proxyBuilder.GetServiceName("Ho", "PSrv",true);

            //Assert
            Assert.AreEqual(name, "hoPSrv");
        }

        [Test]
        public void ControllerSuffix_Null_LowerFirstChar_True()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true });

            //Act
            var name = proxyBuilder.GetServiceName("Ho", null, true);

            //Assert
            Assert.AreEqual(name, "ho");
        }

        [Test]
        public void ControllerSuffix_Null_LowerFirstChar_False()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = false });

            //Act
            var name = proxyBuilder.GetServiceName("Ho", null, false);

            //Assert
            Assert.AreEqual(name, "Ho");
        }
    }
}   
