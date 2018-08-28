using System.Threading.Tasks;
using BasicFeatureToggle.Internal;

namespace BasicFeatureToggle
{
    public class ObjectFeatureToggle : IFeatureToggle
    {
        /// <summary>
        /// A toggle that will return an object value
        /// </summary>
        /// <param name="featureValue">value of the feature toggle</param>
        public ObjectFeatureToggle(object featureValue)
        {
            FeatureValue = featureValue ?? throw new BasicFeatureToggleConfigurationException($"Feature toggles may not specify a null value. Please check configuration for {GetType().Name}");
        }

        public object FeatureValue { get; }

        public Task<object> GetFeatureToggleValueAsync()
        {
            return Task.FromResult(FeatureValue);
        }
    }
}
