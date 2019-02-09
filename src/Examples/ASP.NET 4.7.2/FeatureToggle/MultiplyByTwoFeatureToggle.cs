using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using BasicFeatureToggle;

namespace AspNet472.FeatureToggle
{
    public class MultiplyByTwoFeatureToggle : BooleanFeatureToggle
    {
        public override bool FeatureEnabled => bool.Parse(ConfigurationManager.AppSettings["MultiplyByTwoFeatureToggle"]);
        public override Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken) => Task.FromResult(FeatureEnabled);
    }
}