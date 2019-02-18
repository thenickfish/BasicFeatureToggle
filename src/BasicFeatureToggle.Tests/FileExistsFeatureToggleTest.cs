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
        [TestMethod]
        public async Task FileExistsFeatureToggleReturnsTrueWhenFileExists()
        {
            var filename = $"{Guid.NewGuid()}.txt";
            File.WriteAllText(filename, $"test run for {filename} - {DateTime.Now.ToLongDateString()}");

            var toggle = new TestFileExistsClass(filename);
            Assert.AreEqual(true, toggle.FeatureEnabled);
            Assert.AreEqual(true, await toggle.IsFeatureEnabledAsync(CancellationToken.None));
        }

        [TestMethod]
        public async Task FileExistsFeatureToggleReturnsFalseWhenFileDoesnTExist()
        {
            var filename = $"{Guid.NewGuid()}.txt";
            if (File.Exists(filename))
                File.Delete(filename);

            var toggle = new TestFileExistsClass(filename);
            Assert.AreEqual(false, toggle.FeatureEnabled);
            Assert.AreEqual(false, await toggle.IsFeatureEnabledAsync(CancellationToken.None));
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

            internal Task<bool> IsFeatureEnabledAsync(object none)
            {
                throw new NotImplementedException();
            }
        }
    }
}
