using BasicFeatureToggle.Internal;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public class BooleanFeatureToggle : ObjectFeatureToggle, IBooleanFeatureToggle
    {
        /// <summary>
        /// A simple feature toggle that can be provided a simple true/false configuration value
        /// </summary>
        /// <param name="featureIsEnabled"></param>
        public BooleanFeatureToggle(bool featureIsEnabled): base(featureIsEnabled)
        {
            FeatureEnabled = featureIsEnabled;
        }

        public bool FeatureEnabled { get; }

        public Task<bool> IsFeatureEnabledAsync()
        {
            return Task.FromResult(FeatureEnabled);
        }
    }
}