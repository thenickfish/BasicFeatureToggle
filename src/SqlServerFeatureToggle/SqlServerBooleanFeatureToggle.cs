using BasicFeatureToggle;
using System.Threading;
using System.Threading.Tasks;

namespace SqlFeatureToggle
{
    public abstract class SqlServerBooleanFeatureToggle : SqlServerFeatureToggle<bool>, IBooleanFeatureToggle
    {
        /// <summary>
        ///     This feature toggle will connect to sql server to get a boolean feature toggle value.
        /// </summary>
        /// <param name="settings">configuration to be used while retrieving configuration for this feature toggle.</param>
        public SqlServerBooleanFeatureToggle(SqlServerFeatureToggleSettings settings) : base(settings)
        {
        }

        public bool FeatureEnabled => ToggleValue;
        public Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken) => IsFeatureEnabledAsync(cancellationToken);
    }
}
