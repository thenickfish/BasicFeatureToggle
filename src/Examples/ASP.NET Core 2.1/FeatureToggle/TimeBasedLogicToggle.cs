using BasicFeatureToggle;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore2.FeatureToggle
{
    public class TimeBasedLogicToggle : BooleanFeatureToggle
    {
        public override bool FeatureEnabled => DateTime.Now.Second % 2 == 0;
        public override Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken) => Task.FromResult(FeatureEnabled);
    }
}
