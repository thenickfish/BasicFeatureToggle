using BasicFeatureToggle;
using BasicFeatureToggle.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BasicFeatureToggleTest
{
    [TestClass]
    public class EnabledDuringDateRangeToggleTest
    {
        [TestMethod]
        public async Task EnabledDuringDateRangeToggle_EnablesAfterBeginDate()
        {
            var past = DateTime.Now.AddSeconds(-10);

            var toggle = new EnabledDuringDateRangeToggle(past);
            Assert.IsTrue(toggle.FeatureEnabled);
            Assert.IsTrue(await toggle.IsFeatureEnabledAsync());

            // test with end date present
            var future = DateTime.Now.AddSeconds(10);
            toggle = new EnabledDuringDateRangeToggle(past, future);
            Assert.IsTrue(toggle.FeatureEnabled);
            Assert.IsTrue(await toggle.IsFeatureEnabledAsync());
        }

        [TestMethod]
        public async Task EnabledDuringDateRangeToggle_DisabledPriorToBeginDate()
        {
            var past = DateTime.Now.AddSeconds(-10);
            var future = DateTime.Now.AddSeconds(10);

            var toggle = new EnabledDuringDateRangeToggle(future);
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync());

            // test with end date present
            toggle = new EnabledDuringDateRangeToggle(future, future.AddSeconds(1));
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync());
        }

        [TestMethod]
        public async Task EnabledDuringDateRangeToggle_DisabledAfterEndDate()
        {
            var past = DateTime.Now.AddSeconds(-10);

            var toggle = new EnabledDuringDateRangeToggle(past.AddSeconds(-1), past);
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync());
        }

        [TestMethod]
        public void EnabledDuringDateRangeToggle_ThrowsExceptionForInvalidDateSpan()
        {
            var past = DateTime.Now.AddSeconds(-10);
            var future = DateTime.Now.AddSeconds(10);

            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new EnabledDuringDateRangeToggle(future, past));
            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new EnabledDuringDateRangeToggle(DateTime.MinValue));

        }
    }
}
