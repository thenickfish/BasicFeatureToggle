using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;

namespace AspNetCore2.FeatureToggle
{
    public class MultiplyByTwoFeatureToggle : BooleanFeatureToggle
    {
        public MultiplyByTwoFeatureToggle(IConfiguration configuration) : base(bool.Parse(configuration["BasicFeatureToggle:MultiplyByTwo"]))
        {
        }
    }
}
