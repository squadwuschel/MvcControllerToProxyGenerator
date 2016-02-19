using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using ProxyGenerator.Manager;
using ProxyGenerator.ProxyTypeAttributes;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Manager.MethodParameterManagerTests
{
    [TestFixture]
    public class LoadParameterInfos
    {
        private Type ControllerWithAllTestFunctions { get; set; }

        private MethodParameterManager MethodParameterManager { get; set; }

        [SetUp]
        public void Setup()
        {
            ControllerWithAllTestFunctions = Assembly.GetExecutingAssembly().GetTypes().First(type => type.Name.Contains("LoadParameterInfosOneParam"));
            MethodParameterManager = new MethodParameterManager();
        }

        #region ComplexType
        [Test]
        public void Complexe_Person()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("ComplexPerson");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsTrue(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "person");
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException), ExpectedMessage = "Warning a method with more than one 'complex' parameter was found, thats not supported by ProxyGenerator.")]
        public void Complexe_Exception()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("TwoComplexTypes");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);
        }
        #endregion


        #region SimpleType
        [Test]
        public void SimpleType_Decimal()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("DecimalParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "amount");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "amount2");
        }

        [Test]
        public void SimpleType_Int()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("IntParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Int16()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("Int16Param");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Int32()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("Int32Param");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Int64()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("Int64Param");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Double()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("DoubleParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Long()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("LongParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "age");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "age2");
        }

        [Test]
        public void SimpleType_Boolean()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("BooleanParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "wahr");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "wahr2");
        }

        [Test]
        public void SimpleType_Single()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("SingleParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "one");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "one2");
        }

        [Test]
        public void SimpleType_Byte()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("ByteParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsFalse(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "wahr");

            Assert.IsFalse(methodInfos[1].IsComplexeType);
            Assert.IsFalse(methodInfos[1].IsString);
            Assert.AreEqual(methodInfos[1].ParameterName, "wahr2");
        }

        [Test]
        public void SimpleType_String()
        {
            //Arrange
            var method = ControllerWithAllTestFunctions.GetMethod("StringParam");

            //Act
            var methodInfos = MethodParameterManager.LoadParameterInfos(method);

            //Assert
            Assert.IsFalse(methodInfos[0].IsComplexeType);
            Assert.IsTrue(methodInfos[0].IsString);
            Assert.AreEqual(methodInfos[0].ParameterName, "name");
        }
        #endregion


        /// <summary>
        /// Die Klasse ist nur zum Testen gedacht, damit wir uns per Reflektion die passenden Methoden laden können.
        /// </summary>
        private class LoadParameterInfosOneParam
        {
            public void DecimalParam(decimal amount, decimal? amount2) { }
            public void IntParam(int age, int? age2) { }
            public void Int16Param(Int16 age, Int16? age2) { }
            public void Int32Param(Int32 age, Int32 age2) { }
            public void Int64Param(Int64 age, Int64? age2) { }
            public void DoubleParam(double age, double? age2) { }
            public void LongParam(long age, long? age2) { }
            public void BooleanParam(Boolean wahr, bool? wahr2) { }
            public void SingleParam(Single one, Single? one2) { }
            public void ByteParam(byte wahr, byte? wahr2) { }
            public void DateTimeParam(DateTime datum, DateTime? datum2) { }
            public void StringParam(string name) { }
            public void ComplexPerson(Person person) { }
            public void TwoComplexTypes(Person person, Person person2) { }
        }
    }
}
