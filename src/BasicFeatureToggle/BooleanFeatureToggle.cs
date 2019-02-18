using System.Threading;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public abstract class BooleanFeatureToggle : FlexibleFeatureToggle<bool>, IBooleanFeatureToggle
    {
        /// <summary>
        /// A simple feature toggle that can be provided a simple true/false configuration value
        /// </summary>
        /// <param name="featureIsEnabled"></param>

        public abstract bool FeatureEnabled { get; }
        public abstract Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken);

        protected sealed override bool GetToggleValue() => FeatureEnabled;
        protected sealed override Task<bool> GetToggleValueTask(CancellationToken cancellationToken) => IsFeatureEnabledAsync(cancellationToken);
    }
}