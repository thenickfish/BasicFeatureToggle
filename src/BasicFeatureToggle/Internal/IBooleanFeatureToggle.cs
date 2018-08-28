using System.Threading.Tasks;

namespace BasicFeatureToggle.Internal
{
    public interface IBooleanFeatureToggle
    {
        bool FeatureEnabled { get; }
        Task<bool> IsFeatureEnabledAsync();
    }
}