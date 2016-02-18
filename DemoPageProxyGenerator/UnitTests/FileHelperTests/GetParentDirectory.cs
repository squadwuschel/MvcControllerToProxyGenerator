using System;
using NUnit.Framework;
using ProxyGenerator;
using ProxyGenerator.Container;
using ProxyGenerator.Manager;

namespace UnitTests.FileHelperTests
{
    [TestFixture]
    public class GetParentDirectory
    {
        [Test]
        public void Path_Found()
        {
            //Arrange
            var fileHelper = new FileHelper(new ProxyGeneratorFactoryManager(new ProxySettings()));
            var basePath = @"C:\Temp\Files\MyProjectDirectory\OtherDirectory\Bin\Debug\Test";

            //Act
            var path = fileHelper.GetParentDirectory(basePath, "MyProjectDirectory");

            //Assert
            Assert.AreEqual(path, @"C:\Temp\Files\MyProjectDirectory");
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The 'WebProjectPath' was not found, because the 'WebProjectName' was wrong.")]
        public void Path_Not_Found()
        {
            //Arrange
            var fileHelper = new FileHelper(new ProxyGeneratorFactoryManager(new ProxySettings()));
            var basePath = @"C:\Temp\Files\MyProjectDirectory\OtherDirectory\Bin\Debug\Test";

            //Act
            var path = fileHelper.GetParentDirectory(basePath, "MyProjectDir");
        }
    }
}
