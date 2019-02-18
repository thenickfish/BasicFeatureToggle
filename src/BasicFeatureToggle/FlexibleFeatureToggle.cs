using System.Threading;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    /// <summary>
    /// This toggle returns any generic type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FlexibleFeatureToggle<T> : IFeatureToggle<T>
    {
        protected abstract Task<T> GetToggleValueTask(CancellationToken cancellationToken);
        protected abstract T GetToggleValue();
        public T ToggleValue => GetToggleValue();
        public Task<T> GetToggleValueAsync(CancellationToken cancellationToken) => GetToggleValueTask(cancellationToken);
    }
}
