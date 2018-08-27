using System.Threading.Tasks;

namespace BasicFeatureToggle.Interfaces
{
    internal interface IFeatureToggleAsync
    {
        Task<bool> IsFeatureEnabledAsync();
    }
}