using BasicFeatureToggle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BasicFeatureToggleTest
{
    [TestClass]
    public class BooleanFeatureToggleTest
    {
        [TestMethod]
        public async Task TestBooleanFeatureToggleValuesReturn()
        {
            var toggle = new BooleanFeatureToggle(true);
            Assert.IsTrue((bool) toggle.ToggleValue);
            Assert.IsTrue(toggle.FeatureEnabled);
            Assert.IsTrue(await toggle.IsFeatureEnabledAsync());
            Assert.IsTrue((bool) await toggle.GetToggleValueAsync());

            toggle = new BooleanFeatureToggle(false);
            Assert.IsFalse((bool) toggle.ToggleValue);
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync());
            Assert.IsFalse((bool) await toggle.GetToggleValueAsync());
        }
    }
}
