using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FileData;

namespace FileDataTest
{
    [TestClass]
    public class CommandManagerTest
    {
        IFileManager commandManager = null;
        [TestInitialize]
        public void SetUp()
        {
            commandManager = new FileManager();
        }
        [TestMethod]
        [Description("Update file data using valid version command")]
        public void UpdateFileData_version_pass_Test()
        {
            //Arrange..
            bool expectedResult = true;            
            string[] args = new string[] { "-v", "C:/test.txt" };

            //Act
            bool actualResult = commandManager.UpdateFileData(args);

            //Assert 
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [Description("Update file data using valid size command")]
        public void UpdateFileData_size_pass_Test()
        {
            //Arrange..
            bool expectedResult = true;
            string[] args = new string[] { "-s", "C:/test.txt" };

            //Act
            bool actualResult = commandManager.UpdateFileData(args);

            //Assert 
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [Description("Update file data test for all valid sizes and versions")]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void UpdateFileData_all_versions_size_pass_Test(string command)
        {
            //Arrange..
            bool expectedResult = true;

            //Act
            bool actualResult = commandManager.UpdateFileData(new string[] { command, "C:/test.txt" });

            //Assert 
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [Description("Update file data test for possible Invalid sizes and versions")]
        [DataRow("")]
        [DataRow("-T")]
        [DataRow("--Vision")]
        public void UpdateFileData_Invalid_versions_size_fail_Test(string command)
        {
            //Arrange..
            bool expectedResult = false;

            //Act
            bool actualResult = commandManager.UpdateFileData(new string[] { command, "C:/test.txt" });

            //Assert 
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [Description("Update file data exception Test for invalid command")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFileData_command_Exception_Test(string command)
        {
            //Act
            bool actualResult = commandManager.UpdateFileData(new string[] { command, "C:/test.txt" });

        }

        [TestMethod]
        [Description("Update file data exception Test for invalid file path")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("  ")]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateFileData_filepath_Exception_Test(string filePath)
        {
            //Act
            bool actualResult = commandManager.UpdateFileData(new string[] { "-v", filePath });

        }
    }
}
