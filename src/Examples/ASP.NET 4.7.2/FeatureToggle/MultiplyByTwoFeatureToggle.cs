using BasicFeatureToggle;

namespace AspNet472.FeatureToggle
{
    public class MultiplyByTwoFeatureToggle : BooleanFeatureToggle
    {
        public MultiplyByTwoFeatureToggle(bool featureIsEnabled) : base(featureIsEnabled)
        {
        }
    }
}