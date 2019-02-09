using System;

namespace BasicFeatureToggle
{
    public class BasicFeatureToggleConfigurationException : Exception
    {
        public BasicFeatureToggleConfigurationException(string message) : base(message)
        {
        }
    }
}