using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderDataTypeHelperTests
{
    [TestFixture]
    public class HasReturnType
    {
        [Test]
        public void HasReturnType_True()
        {
            //Arrange
            var proxyBuilderDataTypeHelper = new ProxyBuilderDataTypeHelper(new ProxySettings());

            //Act
            var result = proxyBuilderDataTypeHelper.HasReturnType(typeof (string));

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HasReturnType_False_Null()
        {
            //Arrange
            var proxyBuilderDataTypeHelper = new ProxyBuilderDataTypeHelper(new ProxySettings());

            //Act
            var result = proxyBuilderDataTypeHelper.HasReturnType(null);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void HasReturnType_False_Void()
        {
            //Arrange
            var proxyBuilderDataTypeHelper = new ProxyBuilderDataTypeHelper(new ProxySettings());

            //Act
            var result = proxyBuilderDataTypeHelper.HasReturnType(typeof(void));

            //Assert
            Assert.IsFalse(result);
        }


    }
}
