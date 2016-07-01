using NUnit.Framework;
using ProxyGenerator;
using ProxyGenerator.Container;
using ProxyGenerator.Manager;

namespace UnitTests.FileHelperTests
{
    [TestFixture]
    public class GetProxyFileOutputPath
    {

        [Test]
        public void GetProxyFileOutputPath_Success()
        {
            //Arrange
            var proxySettings = new ProxySettings()
            {
                FullPathToTheWebProject = @"C:\Temp\Files\MyProjectDirectory\OtherDirectory\Bin\Debug\Test",
                WebProjectName = "MyProjectDirectory",
                ProxyFileOutputPath = @"ScriptsApp\services"
            };

            var fileHelper = new FileHelper(new ProxyGeneratorFactoryManager(proxySettings));

            //Act
            var path = fileHelper.GetProxyFileOutputPath("homePSrv.js", null);

            //Assert
            Assert.AreEqual(path, @"C:\Temp\Files\MyProjectDirectory\ScriptsApp\services\homePSrv.js");
        }

        [Test]
        public void GetProxyFileOutputPath_No_ProxyFileOutputPath()
        {
            //Arrange
            var proxySettings = new ProxySettings()
            {
                FullPathToTheWebProject = @"C:\Temp\Files\MyProjectDirectory\OtherDirectory\Bin\Debug\Test",
                WebProjectName = "MyProjectDirectory",
                ProxyFileOutputPath = string.Empty
            };

            var fileHelper = new FileHelper(new ProxyGeneratorFactoryManager(proxySettings));

            //Act
            var path = fileHelper.GetProxyFileOutputPath("homePSrv.js", null);

            //Assert
            Assert.AreEqual(path, "homePSrv.js");
        }

        [Test]
        public void GetProxyFileOutputPath_AlternateOutputPath()
        {
            //Arrange
            var proxySettings = new ProxySettings()
            {
                FullPathToTheWebProject = @"C:\Temp\Files\MyProjectDirectory\OtherDirectory\Bin\Debug\Test",
                WebProjectName = "MyProjectDirectory",
                ProxyFileOutputPath = string.Empty
            };

            var fileHelper = new FileHelper(new ProxyGeneratorFactoryManager(proxySettings));

            //Act
            var path = fileHelper.GetProxyFileOutputPath("homePSrv.js", "alternatePath");

            //Assert
            Assert.AreEqual(path, @"C:\Temp\Files\MyProjectDirectory\alternatePath\homePSrv.js");
        }
    }
}
