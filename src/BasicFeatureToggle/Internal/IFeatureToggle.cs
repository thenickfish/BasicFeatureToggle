using System.Threading.Tasks;

namespace BasicFeatureToggle.Internal
{
    internal interface IFeatureToggle
    {
        object FeatureValue { get; }
        Task<object> GetFeatureToggleValueAsync();
    }
}