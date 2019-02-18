using BasicFeatureToggle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BasicFeatureToggleTest
{
    [TestClass]
    public class FileExistsFeatureToggleTest
    {
        private string _testFileName;
        private TestFileExistsClass _testToggle;

        [TestInitialize]
        public void TestInit()
        {
            _testFileName = $"{Guid.NewGuid()}.txt";
            File.WriteAllText(_testFileName, "TestToggle");
            _testToggle = new TestFileExistsClass(_testFileName);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_testFileName))
                File.Delete(_testFileName);
        }

        [TestMethod]
        public async Task FileExistsFeatureToggleReturnsTrueWhenFileExists()
        {
            Assert.AreEqual(true, _testToggle.FeatureEnabled);
            Assert.AreEqual(true, await _testToggle.IsFeatureEnabledAsync(CancellationToken.None));

            File.Delete(_testFileName);

            Assert.AreEqual(false, _testToggle.FeatureEnabled);
            Assert.AreEqual(false, await _testToggle.IsFeatureEnabledAsync(CancellationToken.None));

        }

        [TestMethod]
        public async Task FileExistsFeatureToggleReturnsFalseWhenFileDoesnTExist()
        {
            File.Delete(_testFileName);

            Assert.AreEqual(false, _testToggle.FeatureEnabled);
            Assert.AreEqual(false, await _testToggle.IsFeatureEnabledAsync(CancellationToken.None));
        }

        [TestMethod]
        public void FileExistsFeatureToggleThrowsExceptionWhenPathIsEmpty()
        {
            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new TestFileExistsClass(""));
        }

        private class TestFileExistsClass : FileExistsFeatureToggle
        {
            public TestFileExistsClass(string fileName) : base(fileName)
            {
            }
        }
    }
}
