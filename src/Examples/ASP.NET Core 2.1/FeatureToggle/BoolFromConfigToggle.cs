using System.Threading;
using System.Threading.Tasks;
using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;

namespace AspNetCore2.FeatureToggle
{
    public class BoolFromConfigToggle : BooleanFeatureToggle
    {
        private readonly IConfiguration _configuration;
        public BoolFromConfigToggle(IConfiguration configuration) => _configuration = configuration;
        public override bool FeatureEnabled => bool.Parse(_configuration["BasicFeatureToggle:MultiplyByTwo"]);
        public override Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken) => Task.FromResult(FeatureEnabled);
    }
}
