using BasicFeatureToggle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
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

            var toggle = new TestDateRangeToggle(past);
            Assert.IsTrue(toggle.FeatureEnabled);
            Assert.IsTrue(await toggle.IsFeatureEnabledAsync(CancellationToken.None));

            // test with end date present
            var future = DateTime.Now.AddSeconds(10);
            toggle = new TestDateRangeToggle(past, future);
            Assert.IsTrue(toggle.FeatureEnabled);
            Assert.IsTrue(await toggle.IsFeatureEnabledAsync(CancellationToken.None));
        }

        [TestMethod]
        public async Task EnabledDuringDateRangeToggle_DisabledPriorToBeginDate()
        {
            var past = DateTime.Now.AddSeconds(-10);
            var future = DateTime.Now.AddSeconds(10);

            var toggle = new TestDateRangeToggle(future);
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync(CancellationToken.None));

            // test with end date present
            toggle = new TestDateRangeToggle(future, future.AddSeconds(1));
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync(CancellationToken.None));
        }

        [TestMethod]
        public async Task EnabledDuringDateRangeToggle_DisabledAfterEndDate()
        {
            var past = DateTime.Now.AddSeconds(-10);

            var toggle = new TestDateRangeToggle(past.AddSeconds(-1), past);
            Assert.IsFalse(toggle.FeatureEnabled);
            Assert.IsFalse(await toggle.IsFeatureEnabledAsync(CancellationToken.None));
        }

        [TestMethod]
        public void EnabledDuringDateRangeToggle_ThrowsExceptionForInvalidDateSpan()
        {
            var past = DateTime.Now.AddSeconds(-10);
            var future = DateTime.Now.AddSeconds(10);

            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new TestDateRangeToggle(future, past));
            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new TestDateRangeToggle(DateTime.MinValue));

        }

        private class TestDateRangeToggle : DateRangeToggle
        {
            public TestDateRangeToggle(DateTime enableDate, DateTime? disableDate = null, bool useUtcTime = false) : base(enableDate, disableDate, useUtcTime)
            {
            }
        }
    }
}
