using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;
using UnitTests.TestHelper.TestClasses;

namespace UnitTests.Builder.Helper.ProxyBuilderDataTypeHelperTests
{
    [TestFixture]
    public class GetTsType
    {
        #region Setup
        private ProxyBuilderDataTypeHelper _proxyBuilderDataTypeHelper;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _proxyBuilderDataTypeHelper = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = "I"});
        }
        #endregion

        #region Tests

        [Test]
        public void GetTsType_Guid()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof (Guid));

            //Assert
            Assert.AreEqual("System.IGuid", result);
        }

        [Test]
        public void GetTsType_Dictionary()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(IDictionary<Datenklasse, Infoklasse>));

            //Assert
            Assert.AreEqual("System.Collections.Generic.KeyValuePair<UnitTests.TestHelper.TestClasses.IDatenklasse, UnitTests.TestHelper.TestClasses.IInfoklasse>[]", result);
        }

        [Test]
        public void GetTsType_SimpleGeneric()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof (Oberklasse<Datenklasse>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IOberklasse<UnitTests.TestHelper.TestClasses.IDatenklasse>", result);
        }

        [Test]
        public void GetTsType_ExtendedGeneric()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Oberklasse2<Datenklasse, Infoklasse>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IOberklasse2<UnitTests.TestHelper.TestClasses.IDatenklasse, UnitTests.TestHelper.TestClasses.IInfoklasse>", result);
        }

        [Test]
        public void GetTsType_Guid_Nullable()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Guid?));

            //Assert
            Assert.AreEqual("System.IGuid", result);
        }

        [Test]
        public void GetTsType_Null()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(null);

            //Assert
            Assert.AreEqual("void", result);
        }

        [Test]
        public void GetTsType_Void()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(void));

            //Assert
            Assert.AreEqual("void", result);
        }

        [Test]
        public void GetTsType_IsGenericType_IEnumerable_Person()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(IEnumerable<Person>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_IEnumerable_string()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(IEnumerable<string>));

            //Assert
            Assert.AreEqual("string[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_IList_Person()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(IList<Person>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_IList_number()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(IList<int>));

            //Assert
            Assert.AreEqual("number[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_List_Person()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(List<Person>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_List_number()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(List<int>));

            //Assert
            Assert.AreEqual("number[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_List_List_Person()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(List<List<Person>>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson[][]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_List_List_number()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(List<List<int>>));

            //Assert
            Assert.AreEqual("number[][]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_Array_string()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(string[]));

            //Assert
            Assert.AreEqual("string[]", result);
        }

        [Test]
        public void GetTsType_IsGenericType_ICollection()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(ICollection<Person>));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson[]", result);
        }

        [Test]
        public void GetTsType_string()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(string));

            //Assert
            Assert.AreEqual("string", result);
        }

        [Test]
        public void GetTsType_int()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(int));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_int()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(int?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_int16()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int16));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_int16()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int16?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_int32()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int32));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_int32()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int32?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_int64()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int64));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_int64()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Int64?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_long()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(long?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_long()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(long));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_decimal()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(decimal));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_decimal()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(decimal?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_double()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(double));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_double()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(double?));

            //Assert
            Assert.AreEqual("number", result);
        }


        [Test]
        public void GetTsType_byte()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(byte));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_byte()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(byte?));

            //Assert
            Assert.AreEqual("number", result);
        }


        [Test]
        public void GetTsType_single()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Single));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_Nullable_single()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Single?));

            //Assert
            Assert.AreEqual("number", result);
        }

        [Test]
        public void GetTsType_datetime()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(DateTime));

            //Assert
            Assert.AreEqual("any", result);
        }

        [Test]
        public void GetTsType_Nullable_datetime()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(DateTime?));

            //Assert
            Assert.AreEqual("any", result);
        }

        [Test]
        public void GetTsType_boolean()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Boolean));

            //Assert
            Assert.AreEqual("boolean", result);
        }

        [Test]
        public void GetTsType_Nullable_boolean()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Boolean?));

            //Assert
            Assert.AreEqual("boolean", result);
        }

        [Test]
        public void GetTsType_ComplexType_Person()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(Person));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.IPerson", result);
        }

        [Test]
        public void GetTsType_ComplexType_Person_No_I()
        {
            //Arrange
            var proxyBuilder = new ProxyBuilderDataTypeHelper(new ProxySettings() { TypeLiteInterfacePrefix = string.Empty});

            //Act
            var result = proxyBuilder.GetTsType(typeof(Person));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.Person", result);
        }

        [Test]
        public void GetTsType_ComplexType_TestEnum()
        {
            //Act
            var result = _proxyBuilderDataTypeHelper.GetTsType(typeof(TestEnum));

            //Assert
            Assert.AreEqual("UnitTests.TestHelper.TestClasses.TestEnum", result);
        }
        #endregion
    }
}
