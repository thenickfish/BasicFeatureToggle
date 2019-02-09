using System.Threading.Tasks;

namespace BasicFeatureToggle.Internal
{
    public interface IFeatureToggle<T>
    {
        T ToggleValue { get; }
        Task<T> GetToggleValueAsync();
    }
}