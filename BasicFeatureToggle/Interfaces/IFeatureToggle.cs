namespace BasicFeatureToggle.Interfaces
{
    public interface IFeatureToggle
    {
        bool FeatureEnabled { get; }
    }
}