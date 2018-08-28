using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;

namespace AspNetCore2.FeatureToggle
{
    public class AddExtraToResultFeatureToggle : ObjectFeatureToggle
    {
        public AddExtraToResultFeatureToggle(IConfiguration configuration) : base(configuration["BasicFeatureToggle:AddExtraToResult"])
        {
        }
    }
}
