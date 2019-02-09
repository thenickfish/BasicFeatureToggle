using BasicFeatureToggle.Internal;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public abstract class BooleanFeatureToggle : ObjectFeatureToggle<bool>, IBooleanFeatureToggle
    {
        /// <summary>
        /// A simple feature toggle that can be provided a simple true/false configuration value
        /// </summary>
        /// <param name="featureIsEnabled"></param>

        public abstract bool FeatureEnabled { get; }
        public abstract Task<bool> IsFeatureEnabledAsync();

        protected override bool GetToggleValue() => FeatureEnabled;
        protected override Task<bool> GetToggleValueTask() => IsFeatureEnabledAsync();
    }
}