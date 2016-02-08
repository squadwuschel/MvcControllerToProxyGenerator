using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class GetProxyFunctionName
    {
        [Test]
        public void LowerFirstChar_True()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true});

            //Act
            var name = proxyBuilder.GetProxyFunctionName("GetMember");

            //Assert
            Assert.AreEqual(name, "getMember");
        }

        [Test]
        public void LowerFirstChar_False()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = false });

            //Act
            var name = proxyBuilder.GetProxyFunctionName("GetMember");

            //Assert
            Assert.AreEqual(name, "GetMember");
        }

        [Test]
        public void LowerFirstChar_True_Methodname_One_CharLength()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true });

            //Act
            var name = proxyBuilder.GetProxyFunctionName("G");

            //Assert
            Assert.AreEqual(name, "g");
        }

        [Test]
        public void LowerFirstChar_True_Methodname_Two_CharLength()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderHelper(new ProxySettings() { LowerFirstCharInFunctionName = true });

            //Act
            var name = proxyBuilder.GetProxyFunctionName("Ge");

            //Assert
            Assert.AreEqual(name, "ge");
        }

    }
}
