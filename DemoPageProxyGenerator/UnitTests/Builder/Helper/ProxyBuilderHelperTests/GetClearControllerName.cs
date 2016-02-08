using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class GetClearControllerName
    {
        [Test]
        public void With_Controller_Suffix()
        {
            //Arrange
            var testClassType = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("MeinTestController"));
            var proxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());

            //Act
            var clearName = proxyBuildHelper.GetClearControllerName(testClassType);

            //Assert
            Assert.AreEqual(clearName, "MeinTest");
        }

        [Test]
        public void No_Controller_Suffix()
        {
            //Arrange
            var testClassType = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("MeinTestOhneCtrl"));
            var proxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());

            //Act
            var clearName = proxyBuildHelper.GetClearControllerName(testClassType);

            //Assert
            Assert.AreEqual(clearName, "MeinTestOhneCtrl");
        }

        private class MeinTestController { }
        private class MeinTestOhneCtrl { }
    }
}
