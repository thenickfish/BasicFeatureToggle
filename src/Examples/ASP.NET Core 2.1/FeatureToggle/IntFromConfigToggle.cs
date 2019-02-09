using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore2.FeatureToggle
{
    public class IntFromConfigToggle: FlexibleFeatureToggle<int>
    {
        private readonly IConfiguration configuration;
        public IntFromConfigToggle(IConfiguration configuration) => this.configuration = configuration;
        protected override int GetToggleValue() => Convert.ToInt32(configuration["BasicFeatureToggle:AddExtraToResult"]);
        protected override Task<int> GetToggleValueTask(CancellationToken cancellationToken) => Task.FromResult(GetToggleValue());
    }
}
