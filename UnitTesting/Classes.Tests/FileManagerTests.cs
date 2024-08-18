using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classes.Tests
{
    [TestClass]
    public class FileManagerTests
    {
        private const string BAD_FILE_NAME = @"C:\Bad.bad";

        private const string GOOD_FILE_NAME = @"C:\Windows\notepad.exe";

        public TestContext testContext { get; set; }

        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;

            //Act
            var goodFileName = testContext.Properties["GoodFileName"].ToString();
            testContext.WriteLine("Checking File" + goodFileName);
            fromCall = fileManager.IsFileExists(goodFileName);

            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;

            //Act
            fromCall = fileManager.IsFileExists(BAD_FILE_NAME);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            // Arrange
            FileManager fileManager = new FileManager();

            //Act
            fileManager.IsFileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            // Arrange
            FileManager fileManager = new FileManager();

            //Act
            try
            {
                fileManager.IsFileExists("");
            }
            catch(ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullException.");
        }
    }
}
