using BasicFeatureToggle;
using BasicFeatureToggle.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BasicFeatureToggleTest
{
    [TestClass]
    public class ObjectFeatureToggleTest
    {
        [TestMethod]
        public async Task TestObjectFeatureToggleValuesReturn()
        {
            var toggle = new ObjectFeatureToggle(1);
            Assert.AreEqual(1, toggle.FeatureValue);
            Assert.AreEqual(1, await toggle.GetFeatureToggleValueAsync());

            toggle = new ObjectFeatureToggle("yellow");
            Assert.AreEqual("yellow", toggle.FeatureValue);
            Assert.AreEqual("yellow", await toggle.GetFeatureToggleValueAsync());

            var now = DateTime.Now;
            toggle = new ObjectFeatureToggle(now);
            Assert.AreEqual(now, toggle.FeatureValue);
            Assert.AreEqual(now, await toggle.GetFeatureToggleValueAsync());
        }

        [TestMethod]
        public void TestObjectFeatureToggleRejectsNulls()
        {
            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new ObjectFeatureToggle(null));
        }
    }
}
