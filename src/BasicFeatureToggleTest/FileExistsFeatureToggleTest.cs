using BasicFeatureToggle;
using BasicFeatureToggle.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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

            var toggle = new FileExistsFeatureToggle(filename);
            Assert.AreEqual(true, toggle.FeatureEnabled);
            Assert.AreEqual(true, await toggle.IsFeatureEnabledAsync());
        }

        [TestMethod]
        public async Task FileExistsFeatureToggleReturnsFalseWhenFileDoesnTExist()
        {
            var filename = $"{Guid.NewGuid()}.txt";
            if (File.Exists(filename))
                File.Delete(filename);

            var toggle = new FileExistsFeatureToggle(filename);
            Assert.AreEqual(false, toggle.FeatureEnabled);
            Assert.AreEqual(false, await toggle.IsFeatureEnabledAsync());
        }

        [TestMethod]
        public void FileExistsFeatureToggleThrowsExceptionWhenPathIsEmpty()
        {
            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new FileExistsFeatureToggle(""));
        }
    }
}
