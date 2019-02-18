using System.Threading;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public interface IFeatureToggle<T>
    {
        T ToggleValue { get; }
        Task<T> GetToggleValueAsync(CancellationToken cancellationToken);
    }
}