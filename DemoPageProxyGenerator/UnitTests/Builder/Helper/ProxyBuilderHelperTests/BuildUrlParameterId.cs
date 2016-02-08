using System.Collections.Generic;
using NUnit.Framework;
using ProxyGenerator.Builder.Helper;
using ProxyGenerator.Container;

namespace UnitTests.Builder.Helper.ProxyBuilderHelperTests
{
    [TestFixture]
    public class BuildUrlParameterId
    {
        private ProxyBuilderHelper ProxyBuildHelper { get; set; }

        [SetUp]
        public void Setup()
        {
            ProxyBuildHelper = new ProxyBuilderHelper(new ProxySettings());
        }

        [Test]
        public void UrlParam_Id()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "laenge" });
            methodParameterInfos.Add(new ProxyMethodParameterInfo() { IsComplexeType = false, IsString = false, ParameterName = "id" });

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameterId(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, " + '/' + id");
        }

        [Test]
        public void NoParams()
        {
            //Arrange
            var methodParameterInfos = new List<ProxyMethodParameterInfo>();

            //Act 
            var paramInfos = ProxyBuildHelper.BuildUrlParameterId(methodParameterInfos);

            //Assert
            Assert.AreEqual(paramInfos, string.Empty);
        }
    }
}
