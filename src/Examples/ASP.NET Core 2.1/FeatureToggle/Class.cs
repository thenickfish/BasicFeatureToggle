using BasicFeatureToggle;
using System;
using System.Threading.Tasks;

namespace AspNetCore2.FeatureToggle
{
    public class DtmToggle : ObjectFeatureToggle<DateTime>
    {
        protected override DateTime GetToggleValue() => DateTime.Now;
        protected override Task<DateTime> GetToggleValueTask() => Task.FromResult(GetToggleValue());
    }
}
