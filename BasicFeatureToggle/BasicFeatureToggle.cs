using BasicFeatureToggle.Interfaces;

namespace BasicFeatureToggle
{
    public class BasicFeatureToggle : IFeatureToggle
    {
        /// <summary>
        /// A simple feature toggle that can be provided a configuration value
        /// </summary>
        /// <param name="featureIsEnabled"></param>
        public BasicFeatureToggle(bool featureIsEnabled)
        {
            FeatureEnabled = featureIsEnabled;
        }

        public bool FeatureEnabled { get; }
    }
}