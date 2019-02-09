using BasicFeatureToggle;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AspNetCore2.FeatureToggle
{
    public class AddExtraToResultFeatureToggle : ObjectFeatureToggle<int>
    {
        private readonly IConfiguration configuration;
        public AddExtraToResultFeatureToggle(IConfiguration configuration) => this.configuration = configuration;
        protected override int GetToggleValue() => Convert.ToInt32(configuration["BasicFeatureToggle:AddExtraToResult"]);
        protected override Task<int> GetToggleValueTask() => Task.FromResult(GetToggleValue());
    }
}
