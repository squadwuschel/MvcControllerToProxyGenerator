using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderDataTypeHelperTests
{
    [TestFixture]
    public class AddInterfacePrefixToFullName
    {
        [Test]
        public void AddInterfacePrefixToFullName_NoEnum_NoPrefix()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = ""});
            
            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Test.Common.Person", false);

            //Assert
            Assert.AreEqual("Test.Common.Person", result);
        }

        [Test]
        public void AddInterfacePrefixToFullName_NoEnum_I_Prefix()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Test.Common.Person", false);

            //Assert
            Assert.AreEqual("Test.Common.IPerson", result);
        }

        [Test]
        public void AddInterfacePrefixToFullName_NoEnum_I_Prefix_NoNs()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Person", false);

            //Assert
            Assert.AreEqual("IPerson", result);
        }

        [Test]
        public void AddInterfacePrefixToFullName_NoEnum_NoPrefix_NoNs()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "" });

            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Person", false);

            //Assert
            Assert.AreEqual("Person", result);
        }

        [Test]
        public void AddInterfacePrefixToFullName_Enum_NoPrefix()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "" });

            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Test.Common.TestEnum", true);

            //Assert
            Assert.AreEqual("Test.Common.TestEnum", result);
        }

        [Test]
        public void AddInterfacePrefixToFullName_Enum_I_Prefix()
        {
            //Arrange
            var proxyBuilderDataType = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I" });

            //Act 
            var result = proxyBuilderDataType.AddInterfacePrefixToFullName("Test.Common.TestEnum", true);

            //Assert
            Assert.AreEqual("Test.Common.TestEnum", result);
        }
    }
}
