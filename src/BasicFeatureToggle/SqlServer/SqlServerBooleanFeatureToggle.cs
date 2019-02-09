using BasicFeatureToggle.Internal;
using System.Threading.Tasks;

namespace BasicFeatureToggle.SqlServer
{
    public class SqlServerBooleanFeatureToggle : SqlServerFeatureToggle<bool>, IBooleanFeatureToggle
    {
        /// <summary>
        ///     This feature toggle will connect to sql server to get a boolean feature toggle value.
        /// </summary>
        /// <param name="settings">configuration to be used while retrieving configuration for this feature toggle.</param>
        public SqlServerBooleanFeatureToggle(SqlServerFeatureToggleSettings settings) : base(settings)
        {
        }

        public bool FeatureEnabled => (bool) GetFeatureToggleValue();

        public async Task<bool> IsFeatureEnabledAsync()
        {
            return (bool) await GetFeatureToggleValueAsync();
        } 
    }
}
