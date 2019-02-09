using System.Threading.Tasks;

namespace BasicFeatureToggle.Internal
{
    public interface IBooleanFeatureToggle: IFeatureToggle<bool>
    {
        bool FeatureEnabled { get; }
        Task<bool> IsFeatureEnabledAsync();
    }
}