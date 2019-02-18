using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using BasicFeatureToggle;

namespace AspNet472.FeatureToggle
{
    public class AddExtraToResultFeatureToggle : FlexibleFeatureToggle<int>
    {
        protected override int GetToggleValue() => Convert.ToInt32(ConfigurationManager.AppSettings["AddExtraToResultFeatureToggle"]);
        protected override Task<int> GetToggleValueTask(CancellationToken cancellationToken) => Task.FromResult(GetToggleValue());
    }
}