using System;

namespace BasicFeatureToggle.Internal
{
    public class BasicFeatureToggleConfigurationException : Exception
    {
        public BasicFeatureToggleConfigurationException(string message) : base(message)
        {
        }
    }
}