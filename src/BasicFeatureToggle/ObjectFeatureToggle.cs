using System.Threading.Tasks;
using BasicFeatureToggle.Internal;

namespace BasicFeatureToggle
{
    public abstract class ObjectFeatureToggle<T> : IFeatureToggle<T>
    {
        protected abstract Task<T> GetToggleValueTask();
        protected abstract T GetToggleValue();
        public T ToggleValue => GetToggleValue();
        public Task<T> GetToggleValueAsync() => GetToggleValueTask();
    }
}
