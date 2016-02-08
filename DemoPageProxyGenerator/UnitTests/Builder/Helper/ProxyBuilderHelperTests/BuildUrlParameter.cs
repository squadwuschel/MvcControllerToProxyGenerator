using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class BuildUrlParameter
    {
        private ProxyBuilderHelper ProxyBuildHelper { get; set; }

        [SetUp]
        public void Setup()
        {
            ProxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());
        }

        [Test]
        public void NoParams()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, string.Empty);
        }


        [Test]
        public void One_Simple_Param_NoString()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "alter"});

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?alter='+alter");
        }

        [Test]
        public void Two_Simple_Param_NoString()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "laenge" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "alter" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?laenge='+laenge+'&alter='+alter");
        }

        [Test]
        public void Two_Simple_Param_OneString()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "name" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "alter" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?name='+encodeURIComponent(name)+'&alter='+alter");
        }

        [Test]
        public void Two_Simple_Param_TwoStrings()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "name" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "alter" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?name='+encodeURIComponent(name)+'&alter='+encodeURIComponent(alter)");
        }

        [Test]
        public void Three_Simple_Param_TwoStrings_OneNumber()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "name" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "alter" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "laenge" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?name='+encodeURIComponent(name)+'&alter='+encodeURIComponent(alter)+'&laenge='+laenge");
        }

        [Test]
        public void Two_Simple_Param_TwoStrings_And_ParamsName_Id()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "name" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "alter" });
            //Wird nicht mit generiert in der URL!
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "Id" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?name='+encodeURIComponent(name)+'&alter='+encodeURIComponent(alter)");
        }

        [Test]
        public void Two_Simple_Param_TwoStrings_And_ComplexType()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "name" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = true, ParameterName = "alter" });
            //Wird nicht mit generiert in der URL!
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = true, IsString = false, ParameterName = "Person" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameter(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, "+ '?name='+encodeURIComponent(name)+'&alter='+encodeURIComponent(alter)");
        }

    }
}
