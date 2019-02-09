using System.Threading.Tasks;
using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;

namespace AspNetCore2.FeatureToggle
{
    public class MultiplyByTwoFeatureToggle : BooleanFeatureToggle
    {
        private readonly IConfiguration _configuration;
        public MultiplyByTwoFeatureToggle(IConfiguration configuration) => _configuration = configuration;
        public override bool FeatureEnabled => bool.Parse(_configuration["BasicFeatureToggle:MultiplyByTwo"]);
        public override Task<bool> IsFeatureEnabledAsync() => Task.FromResult(FeatureEnabled);
    }
}
