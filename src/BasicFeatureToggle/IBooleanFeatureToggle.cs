using System.Threading;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public interface IBooleanFeatureToggle: IFeatureToggle<bool>
    {
        bool FeatureEnabled { get; }
        Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken);
    }
}